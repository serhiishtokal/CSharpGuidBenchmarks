using System.Diagnostics;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.ServicesProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Tests;

public class DbContextExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DbContextExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task GetEntityCountsParallelAsyncTest()
    {
        var connectionString = CustomConfigurationProvider.Configuration
            .GetConnectionString("DefaultConnection");

        Assert.NotNull(connectionString);
        Assert.NotEmpty(connectionString);

        var serviceCollection = new ServiceCollection()
            .AddDbContextFactory<BenchmarkDbContext>(options =>
                options.UseSqlServer(connectionString));
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<BenchmarkDbContext>>();
        
        // stopwatch
        var stopwatch = Stopwatch.StartNew();
        var dictionary = await dbContextFactory.GetEntityCountsParallelAsync();
        stopwatch.Stop();
        var elapsedMs = stopwatch.ElapsedMilliseconds;
        Assert.NotNull(dictionary);
        _testOutputHelper.WriteLine($"Elapsed time: {elapsedMs} ms");
    }
    
    [Fact]
    public async Task GetEntityCountsAsyncTest()
    {
        var connectionString = CustomConfigurationProvider.Configuration
            .GetConnectionString("DefaultConnection");

        Assert.NotNull(connectionString);
        Assert.NotEmpty(connectionString);

        var serviceCollection = new ServiceCollection()
            .AddDbContextFactory<BenchmarkDbContext>(options =>
                options.UseSqlServer(connectionString));
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<BenchmarkDbContext>>();
        var dbContext = await dbContextFactory.CreateDbContextAsync();
        // stopwatch
        var stopwatch = Stopwatch.StartNew();
        var dictionary = await dbContext.GetEntityCountsAsync();
        stopwatch.Stop();
        var elapsedMs = stopwatch.ElapsedMilliseconds;
        Assert.NotNull(dictionary);
        _testOutputHelper.WriteLine($"Elapsed time: {elapsedMs} ms");
    }
}