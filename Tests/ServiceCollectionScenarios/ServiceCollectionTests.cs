using System.Text.Json;
using CSharpGuidBenchmarks.Application.Services.EntityFactories;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Tests.ServiceCollectionScenarios;

public class ServiceCollectionTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly IServiceCollection _serviceCollection;

    public ServiceCollectionTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _serviceCollection = new ServiceCollection();
    }


    [Fact]
    public void Test1()
    {
        _serviceCollection.AddSingleton(typeof(IEntityFakerProvider<>),typeof(EntityFakerProvider<>));
        
        IServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider();
        
        
        var fakerProvider = serviceProvider.GetRequiredService<IEntityFakerProvider<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity>>();
        fakerProvider.Should().NotBeNull();
        fakerProvider.Faker.Should().NotBeNull();
        var entity = fakerProvider.Faker.Generate();
        entity.Should().NotBeNull();
        // ———> CONTINUATION starts here <———

        // 1. Serialize entity to JSON (pretty-print)
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(entity, options);

        // 2. Assert JSON isn’t empty (optional)
        json.Should().NotBeNullOrEmpty("serialization should yield valid JSON");

        // 3. Write to the test output
        _testOutputHelper.WriteLine("Serialized entity:");
        _testOutputHelper.WriteLine(json);
    }
}