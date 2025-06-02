using BenchmarkDotNet.Attributes;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Services.Abstractions;
using CSharpGuidBenchmarks.ServicesProviders;
using Mawosoft.Extensions.BenchmarkDotNet;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpGuidBenchmarks.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 5)]
public class DbInsertGuidBenchmark
{
    private const int SetupActionChunkSize = 100_000;
    private const int RecordsPerBulkInsert = 10;
    
    [ParamsSource(nameof(EntityTypes))]
    public ParamWrapper<Type> EntityType = null!;
    
    [ParamsSource(nameof(InitialDbRecordsNumberStates))]
    public int InitialDbRecordsNumberState;
    
    public static IEnumerable<ParamWrapper<Type>> EntityTypes
    {
        get
        {
            yield return new ParamWrapper<Type>(typeof(GuidV4Bin16ClusteredPkEntity), nameof(GuidV4Bin16ClusteredPkEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV4ClusteredPkEntity), nameof(GuidV4ClusteredPkEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7Bin16ClusteredPkEntity), nameof(GuidV7Bin16ClusteredPkEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7ClusteredPkEntity), nameof(GuidV7ClusteredPkEntity));
            
            yield return new ParamWrapper<Type>(typeof(IntClusteredPkEntity), nameof(IntClusteredPkEntity));
            
            yield return new ParamWrapper<Type>(typeof(IntClusteredPkWithAlternateGuidV4Bin16Entity), nameof(IntClusteredPkWithAlternateGuidV4Bin16Entity));
            yield return new ParamWrapper<Type>(typeof(IntClusteredPkWithAlternateGuidV4Entity), nameof(IntClusteredPkWithAlternateGuidV4Entity));
            yield return new ParamWrapper<Type>(typeof(IntClusteredPkWithAlternateGuidV7Bin16Entity), nameof(IntClusteredPkWithAlternateGuidV7Bin16Entity));
            yield return new ParamWrapper<Type>(typeof(IntClusteredPkWithAlternateGuidV7Entity), nameof(IntClusteredPkWithAlternateGuidV7Entity));
            
            yield return new ParamWrapper<Type>(typeof(GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV4NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV4NonClusteredPkWithDateTimeClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV7NonClusteredPkWithDateTimeClusteredEntity));
            
            yield return new ParamWrapper<Type>(typeof(GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity), nameof(GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV4NonClusteredPkWithIntSeqClusteredEntity), nameof(GuidV4NonClusteredPkWithIntSeqClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity), nameof(GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7NonClusteredPkWithIntSeqClusteredEntity), nameof(GuidV7NonClusteredPkWithIntSeqClusteredEntity));
            
            yield return new ParamWrapper<Type>(typeof(GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity), nameof(GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV4NonClusteredPkWithLongSeqClusteredEntity), nameof(GuidV4NonClusteredPkWithLongSeqClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity), nameof(GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity));
            yield return new ParamWrapper<Type>(typeof(GuidV7NonClusteredPkWithLongSeqClusteredEntity), nameof(GuidV7NonClusteredPkWithLongSeqClusteredEntity));
        }
    }

    public static IEnumerable<int> InitialDbRecordsNumberStates
    {
        get
        {
            yield return 10_000;
            yield return 50_000;
            yield return 100_000;
            yield return 500_000;
            yield return 1_000_000;
            yield return 5_000_000;
            yield return 10_000_000;
        }
    }
    
    // public static IEnumerable<int> TestInitialDbRecordsNumberStates
    // {
    //     get
    //     {
    //         yield return 20;
    //         yield return 50;
    //         // yield return 100;
    //         // yield return 300;
    //         // yield return 500;
    //         // yield return 1000;
    //     }
    // }
    
    // public static IEnumerable<ParamWrapper<Type>> TestEntityTypes
    // {
    //     get
    //     {
    //         yield return new ParamWrapper<Type>(typeof(GuidV4Bin16ClusteredPkEntity), nameof(GuidV4Bin16ClusteredPkEntity));
    //         yield return new ParamWrapper<Type>(typeof(GuidV4ClusteredPkEntity), nameof(GuidV4ClusteredPkEntity));
    //         // yield return typeof(GuidV7Bin16ClusteredPkEntity);
    //         // yield return typeof(GuidV7ClusteredPkEntity);
    //     }
    // }

    protected IDbInsertGuidBenchmarkService _dbGuidBenchmarkService = null!;

    [GlobalSetup]
    public async Task GlobalSetup()
    {
        var configuration = new DbInsertGuidBenchmarkServiceConfiguration(
            InitialDbRecordsNumberState,
            SetupActionChunkSize,
            RecordsPerBulkInsert,
            EntityType.Value);
        
        var serviceProvider = ServiceProviderFactory.CreateForDbInsertGuidBenchmark(configuration);
        var type = typeof(IDbInsertGuidBenchmarkService<>).MakeGenericType(configuration.EntityType);
        _dbGuidBenchmarkService = (IDbInsertGuidBenchmarkService) serviceProvider.GetRequiredService(type);
        await _dbGuidBenchmarkService.GlobalSetup();
    }
    
    [IterationSetup]
    public void IterationSetup()
    {
        _dbGuidBenchmarkService.IterationSetup().GetAwaiter().GetResult();
    }
    
    [IterationCleanup]
    public void IterationCleanup()
    {
        _dbGuidBenchmarkService.IterationCleanup().GetAwaiter().GetResult();
    }
    
    [Benchmark]
    [IterationCount(10)]
    public async Task SingleInsertLatencyBenchmark()
    {
        await _dbGuidBenchmarkService.SingleInsertLatencyBenchmark();
    }
    
    [Benchmark]
    [IterationCount(10)]
    public async Task BulkInsertLatencyBenchmark()
    {
        await _dbGuidBenchmarkService.BulkInsertLatencyBenchmark();
    }
}
