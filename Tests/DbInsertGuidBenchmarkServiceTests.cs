using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using CSharpGuidBenchmarks.ServicesProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class DbInsertGuidBenchmarkServiceTests
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Faker<GuidV4Bin16ClusteredPkEntity> _guidV4Bin16ClusteredPkEntityFaker;
    private readonly Faker<GuidV4ClusteredPkEntity> _guidV4ClusteredPkEntityFaker;

    public DbInsertGuidBenchmarkServiceTests()
    {
        var configuration = new DbInsertGuidBenchmarkServiceConfiguration(
            20_000,
            100_000,
            5_000);
        
        _serviceProvider = ServiceProviderFactory.CreateForDbInsertGuidBenchmark(configuration);
        var type = typeof(IDbInsertGuidBenchmarkService<>).MakeGenericType(typeof(GuidV4Bin16ClusteredPkEntity));

        
        _guidV4Bin16ClusteredPkEntityFaker = new Faker<GuidV4Bin16ClusteredPkEntity>()
            .CustomInstantiator(f => GuidV4Bin16ClusteredPkEntity.Create(f.Lorem.Sentence()));
        
        _guidV4ClusteredPkEntityFaker = new Faker<GuidV4ClusteredPkEntity>()
            .CustomInstantiator(f => GuidV4ClusteredPkEntity.Create(f.Lorem.Sentence()));
    }


    [Fact]
    public async Task GlobalSetup_ShouldResetAllTableExceptOne()
    {
        var dbContextFactory = _serviceProvider
            .GetRequiredService<IDbContextFactory<BenchmarkDbContext>>();
        var initCount = 2100;
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        await dbContext.RespawnDbAsync();
        await dbContext.Set<GuidV4Bin16ClusteredPkEntity>().AddRangeAsync(_guidV4Bin16ClusteredPkEntityFaker.Generate(initCount));
        await dbContext.Set<GuidV4ClusteredPkEntity>().AddRangeAsync(_guidV4ClusteredPkEntityFaker.Generate(initCount));
        await dbContext.SaveChangesAsync();

        {
            var entityType = typeof(GuidV4Bin16ClusteredPkEntity);
            var serviceType = typeof(IDbInsertGuidBenchmarkService<>).MakeGenericType(entityType);
            var dbGuidBenchmarkService = (IDbInsertGuidBenchmarkService) _serviceProvider.GetRequiredService(serviceType);
            await dbGuidBenchmarkService.GlobalSetup();
        }

        var countOfIgnoredEntityRecords = await dbContext.Set<GuidV4Bin16ClusteredPkEntity>().CountAsync();
        var countOfRemovedEntityRecords = await  dbContext.Set<GuidV4ClusteredPkEntity>().CountAsync();
        
        Assert.Equal(initCount, countOfIgnoredEntityRecords);
        Assert.Equal(0, countOfRemovedEntityRecords);
    }
    
    [Fact]
    public async Task AddGuidV7Bin16ClusteredPkEntityRangeTest()
    {
        var dbContextFactory = _serviceProvider
            .GetRequiredService<IDbContextFactory<BenchmarkDbContext>>();
        var initCount = 2100;
        var faker = new Faker<GuidV7Bin16ClusteredPkEntity>()
            .CustomInstantiator(f => GuidV7Bin16ClusteredPkEntity.Create(f.Lorem.Sentence()));
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        //await dbContext.RespawnDbAsync();
        await dbContext.Set<GuidV7Bin16ClusteredPkEntity>().AddRangeAsync(faker.Generate(initCount));
        await dbContext.SaveChangesAsync();
    }
    
    [Fact]
    public async Task AddGuidV7ClusteredPkEntityRangeTest()
    {
        var dbContextFactory = _serviceProvider
            .GetRequiredService<IDbContextFactory<BenchmarkDbContext>>();
        var initCount = 2100;
        var faker = new Faker<GuidV7ClusteredPkEntity>()
            .CustomInstantiator(f => GuidV7ClusteredPkEntity.Create(f.Lorem.Sentence()));
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        //await dbContext.RespawnDbAsync();
        await dbContext.Set<GuidV7ClusteredPkEntity>().AddRangeAsync(faker.Generate(initCount));
        await dbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task RespawnAsync()
    {
        var dbContextFactory = _serviceProvider
            .GetRequiredService<IDbContextFactory<BenchmarkDbContext>>();
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        await dbContext.RespawnDbAsync();
    }
    
    [Fact]
    public async Task ResetDbAsync()
    {
        var dbContextFactory = _serviceProvider
            .GetRequiredService<IDbContextFactory<BenchmarkDbContext>>();
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        await dbContext.ResetDbAsync();
    }
}