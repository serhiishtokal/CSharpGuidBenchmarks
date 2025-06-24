using Bogus;
using CSharpGuidBenchmarks.Application.Services.Abstractions;
using CSharpGuidBenchmarks.Application.Services.EntityFactories;
using CSharpGuidBenchmarks.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CSharpGuidBenchmarks.Application.Others;

public class DbGuidInsertBenchmarkIterationService<TEntity, TDbContext> : IDbGuidInsertBenchmarkIterationService<TEntity, TDbContext>
    where TEntity : class, ICreatable<TEntity>
    where TDbContext : DbContext
{
    private readonly IDbContextFactory<TDbContext> _dbContextFactory;
    private readonly DbGuidBenchmarkIterationServiceConfiguration _configuration;
    private readonly IDbRespawner _dbRespawner;
    private TEntity[] _iterationEntities;
    private readonly Type _entityType = typeof(TEntity);
    private readonly Faker<TEntity> _faker;
    private readonly ILogger<DbGuidInsertBenchmarkIterationService<TEntity, TDbContext>> _logger;

    public DbGuidInsertBenchmarkIterationService(IDbContextFactory<TDbContext> dbContextFactory, 
        IEntityFakerProvider<TEntity> fakerProvider,
        DbGuidBenchmarkIterationServiceConfiguration configuration, IDbRespawner dbRespawner, ILogger<DbGuidInsertBenchmarkIterationService<TEntity, TDbContext>> logger)
    {
        _dbContextFactory = dbContextFactory;
        _configuration = configuration;
        _dbRespawner = dbRespawner;
        _logger = logger;
        _faker = fakerProvider.Faker;
    }

    public async Task GlobalSetup()
    {
        await LogLine($"GlobalSetup: {_configuration}");
        if (_configuration.CanHardDbRespawn)
        {
            await LogLine("GlobalSetup: Starting hard respawn...");
            await _dbRespawner.HardRespawnAsync();
        }
        else
        {
            await LogLine("GlobalSetup: Starting soft respawn...");
            await _dbRespawner.SoftRespawnAsync(_entityType);
            await LogLine($"{_entityType.ShortDisplayName()} ignored.");
        }

        await LogLine($"GlobalSetup: Database respawned.");
    }

    public Task GlobalCleanup()
    {
        throw new NotImplementedException();
    }

    public async Task IterationSetup()
    {
        await LogLine("IterationSetup: EnsureExactRecordCountSetupAsync...");
        await EnsureExactRecordCountSetupAsync(_configuration.InitialDbRecordsNumberState);
        await LogLine("IterationSetup: Database ready.");

        _iterationEntities = GenerateEntities(_configuration.RecordsPerBulkInsert).ToArray();
        await LogLine("IterationSetup: Starting benchmark...");
    }

    public Task IterationCleanup()
    {
        throw new NotImplementedException();
    }
    
    public async Task SingleInsertLatencyBenchmarkIterationCleanup()
    {
        await LogLine("SingleInsertLatencyBenchmark: Inserted single record.");
    }
    
    public async Task BulkInsertLatencyBenchmarkIterationCleanup()
    {
        await LogLine($"BulkInsertLatencyBenchmark: Inserted {_iterationEntities.Length} records.");
    }
    
    
    public async Task SingleInsertLatencyBenchmark()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddAsync(_iterationEntities[0]);
        await context.SaveChangesAsync();
    }

    public async Task BulkInsertLatencyBenchmark()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddRangeAsync(_iterationEntities);
        await context.SaveChangesAsync();
    }

    public async Task BulkInsertOneByOneLatencyBenchmark()
    {
        for (var i = 0; i < _configuration.RecordsPerBulkInsert; i++)
        {
            var entity = GenerateEntity();
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }

    private IEnumerable<TEntity> GenerateEntities(int count)
    {
        return _faker.GenerateLazy(count);
    }
    
    private TEntity GenerateEntity()
    {
        return _faker.Generate();
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

    private async Task BulkInsertRecordsSetupAsync(TDbContext context, int numberRecordsToInsert)
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

    private async Task BulkDeleteRecordsSetupAsync(TDbContext context, int totalRecordsToDelete)
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

    private Task LogLine(string message)
    {
        var entityTypeString = _entityType.ShortDisplayName();
        var dbContextTypeString = typeof(TDbContext).ShortDisplayName();
        var dbRecordsState = _configuration.InitialDbRecordsNumberState;
        _logger.LogInformation("[{dbContextTypeString}][{entityTypeString} db state {dbRecordsState}] {message}",dbContextTypeString, entityTypeString, dbRecordsState, message);
        return Task.CompletedTask;
    }

    private async Task<int> GetCurrentRecordsCountAsync()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Set<TEntity>().CountAsync();
    }
}