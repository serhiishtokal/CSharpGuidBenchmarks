using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services.Abstractions;

public abstract class DbInsertGuidBenchmarkService<TEntity> : IDbInsertGuidBenchmarkService<TEntity> where TEntity : class
{
    private readonly IDbContextFactory<BenchmarkDbContext> _dbContextFactory;
    private readonly DbInsertGuidBenchmarkServiceConfiguration _configuration;
    private IReadOnlyList<TEntity> _iterationEntities;

    public DbInsertGuidBenchmarkService(IDbContextFactory<BenchmarkDbContext> dbContextFactory, DbInsertGuidBenchmarkServiceConfiguration configuration)
    {
        _dbContextFactory = dbContextFactory;
        _configuration = configuration;
    }
    
    protected abstract TEntity GenerateEntity();
    
    public async Task GlobalSetup()
    {
        Console.WriteLine($"GlobalSetup: {_configuration}");
        await using var benchmarkDbContext = await _dbContextFactory.CreateDbContextAsync();
        await benchmarkDbContext.RespawnDbAsync(_configuration.EntityType);
        Console.WriteLine("GlobalSetup: Database ready.");
    }
    
    public async Task IterationSetup()
    {
        Console.WriteLine("IterationSetup: EnsureExactRecordCountSetupAsync...");
        await EnsureExactRecordCountSetupAsync(_configuration.InitialDbRecordsNumberState);
        Console.WriteLine("IterationSetup: Database ready.");
        
        _iterationEntities = GenerateEntities(_configuration.RecordsPerBulkInsert).ToList();
    }
    
    public async Task IterationCleanup()
    {
        Console.WriteLine("IterationCleanup ...");
        await EnsureExactRecordCountSetupAsync(_configuration.InitialDbRecordsNumberState);
        Console.WriteLine("IterationCleanup: Database ready.");
    }
    
    public async Task SingleInsertLatencyBenchmark()
    {
        var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddAsync(_iterationEntities[0]);
        await context.SaveChangesAsync();
    }
    
    public async Task BulkInsertLatencyBenchmark()
    {
        var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddRangeAsync(_iterationEntities);
        await context.SaveChangesAsync();
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
                Console.WriteLine(
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
    }
    
    private static async Task BulkDeleteRecordsSetupAsync(BenchmarkDbContext context, int recordsToDelete)
    {
        await context.Set<TEntity>()
            .Take(recordsToDelete)
            .ExecuteDeleteAsync();
    }
}

