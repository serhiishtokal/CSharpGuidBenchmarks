using CSharpGuidBenchmarks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CSharpGuidBenchmarks.Services.Abstractions;

public abstract class DbInsertGuidBenchmarkService<TEntity> : IDbInsertGuidBenchmarkService<TEntity>
    where TEntity : class
{
    private readonly IDbContextFactory<BenchmarkDbContext> _dbContextFactory;
    private readonly DbInsertGuidBenchmarkServiceConfiguration _configuration;
    private IReadOnlyList<TEntity> _iterationEntities;
    private Type _entityType => typeof(TEntity);

    public DbInsertGuidBenchmarkService(IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
    {
        _dbContextFactory = dbContextFactory;
        _configuration = configuration;
    }

    protected abstract TEntity GenerateEntity();

    public async Task GlobalSetup()
    {
        await LogLine($"GlobalSetup: {_configuration}");
        await using var benchmarkDbContext = await _dbContextFactory.CreateDbContextAsync();
        await benchmarkDbContext.RespawnDbAsync(_entityType);
        await LogLine($"GlobalSetup: Database respawned. {_entityType.ShortDisplayName()} ignored.");
    }

    // public async Task GlobalCleanup()
    // {
    //     await Log($"GlobalCleanup: {_configuration}");
    //     
    //     await using var benchmarkDbContext = await _dbContextFactory.CreateDbContextAsync();
    //     var countOfRecords = await benchmarkDbContext.Set<TEntity>().CountAsync();
    //     if (countOfRecords <= 0)
    //     {
    //         await Log("GlobalCleanup: No records to delete.");
    //     }
    //     else
    //     {
    //         await Log($"GlobalCleanup: Deleting {countOfRecords} {_configuration.EntityType.GetShortName()} entity records");
    //         await BulkDeleteRecordsSetupAsync(benchmarkDbContext, countOfRecords);
    //     }
    //     
    //     await Log("GlobalSetup: Database ready.");
    // }

    public async Task IterationSetup()
    {
        await LogLine("IterationSetup: EnsureExactRecordCountSetupAsync...");
        await EnsureExactRecordCountSetupAsync(_configuration.InitialDbRecordsNumberState);
        await LogLine("IterationSetup: Database ready.");

        _iterationEntities = GenerateEntities(_configuration.RecordsPerBulkInsert).ToList();
    }

    // public async Task IterationCleanup()
    // {
    //     await Log("IterationCleanup ...");
    //     await using var benchmarkDbContext = await _dbContextFactory.CreateDbContextAsync();
    //     var countOfRecords = await benchmarkDbContext.Set<TEntity>().CountAsync();
    //     await Log("IterationCleanup: Current records count: " + countOfRecords);
    //     await EnsureExactRecordCountSetupAsync(_configuration.InitialDbRecordsNumberState);
    //     await Log("IterationCleanup: Database ready.");
    // }

    public async Task SingleInsertLatencyBenchmark()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddAsync(_iterationEntities[0]);
        await context.SaveChangesAsync();
        await LogLine("SingleInsertLatencyBenchmark: Inserted single record.");
    }

    public async Task BulkInsertLatencyBenchmark()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddRangeAsync(_iterationEntities);
        await context.SaveChangesAsync();
        await LogLine($"BulkInsertLatencyBenchmark: Inserted {_iterationEntities.Count} records.");
    }
    
    public async Task BulkInsertOneByOneLatencyBenchmark()
    {
        for (int i = 0; i < _configuration.RecordsPerBulkInsert; i++)
        {
            var entity = GenerateEntity();
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
        
        await LogLine($"BulkInsertLatencyBenchmark: Inserted {_iterationEntities.Count} records.");
    }

    private IEnumerable<TEntity> GenerateEntities(int count)
    {
        return Enumerable.Range(0, count)
            .Select(_ => GenerateEntity());
    }

    private async Task EnsureExactRecordCountSetupAsync(int targetCount)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var currentCount = await context.Set<TEntity>().CountAsync();
        await LogLine($"Current records count: {currentCount} target: {targetCount}");
        var difference = targetCount - currentCount;

        switch (difference)
        {
            case > 0:
            {
                await BulkInsertRecordsSetupAsync(context, difference);
                break;
            }
            case < 0:
            {
                var recordsToDelete = -difference;
                await BulkDeleteRecordsSetupAsync(context, recordsToDelete);
                break;
            }
            default:
                await LogLine(
                    $"EnsureExactRecordCountAsync: DB already has {currentCount} records. No action needed.");
                break;
        }
    }

    private async Task BulkInsertRecordsSetupAsync(BenchmarkDbContext context, int numberRecordsToInsert)
    {
        if (numberRecordsToInsert <= 0) return;

        var chunks = Enumerable.Range(0, numberRecordsToInsert)
            .Select(x => GenerateEntity())
            .Chunk(_configuration.SetupActionChunkSize);

        context.ChangeTracker.AutoDetectChangesEnabled = false;
        foreach (object[] chunk in chunks)
        {
            context.AddRange(chunk);
            await context.SaveChangesAsync();
        }
        
        await LogLine($"Inserted {numberRecordsToInsert} records");
    }
    
    private async Task BulkDeleteRecordsSetupAsync(BenchmarkDbContext context, int totalRecordsToDelete)
     {
         if (totalRecordsToDelete <= 0) return;
         var setupActionChunkSize = _configuration.SetupActionChunkSize;
         for (long i = 0; i < totalRecordsToDelete; i += setupActionChunkSize)
         {
             var batchSize = (int)Math.Min(setupActionChunkSize, totalRecordsToDelete - i);
             if (batchSize <= 0) break;
             
             var deleted = await context.Set<TEntity>()
                 .Take(batchSize)
                 .ExecuteDeleteAsync();

             if (deleted == 0) break;
         }
         await LogLine($"Deleted {totalRecordsToDelete} records");
     }

    private async Task LogLine(string message)
    {
        var typeString = _entityType.ShortDisplayName();
        var dbState = _configuration.InitialDbRecordsNumberState;
        await Console.Out.WriteLineAsync($"[{typeString} db state {dbState}] {message}");
    }
    
    private async Task<int> GetCurrentRecordsCountAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Set<TEntity>().CountAsync();
    }
}