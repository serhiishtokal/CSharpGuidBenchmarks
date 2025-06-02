using BenchmarkDotNet.Attributes;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
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
    private const int RecordsPerBulkInsert = 5_000;
    
    [ParamsSource(nameof(EntityTypes))]
    public ParamWrapper<Type> EntityType = null!;
    
    [ParamsSource(nameof(GenerateDbRecordStates))]
    public int InitialDbRecordsNumberState;
    
    public static IEnumerable<int> GenerateDbRecordStates
    {
        get
        {
            {
                for (int init = 3_000_000; init <= 16_000_000;)
                {
                    yield return init;
                    int increment;
                    switch (init)
                    {
                        case < 5_000_000:
                            increment = 500_000;
                            break;
                        default:
                            increment = 1_000_000;
                            break;
                    }
        
                    init += increment;
                }
            }
        }
    }
    
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
            
            // yield return new ParamWrapper<Type>(typeof(GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity));
            // yield return new ParamWrapper<Type>(typeof(GuidV4NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV4NonClusteredPkWithDateTimeClusteredEntity));
            // yield return new ParamWrapper<Type>(typeof(GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity));
            // yield return new ParamWrapper<Type>(typeof(GuidV7NonClusteredPkWithDateTimeClusteredEntity), nameof(GuidV7NonClusteredPkWithDateTimeClusteredEntity));
            
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
    
    protected IDbInsertGuidBenchmarkService _dbGuidBenchmarkService = null!;

    [GlobalSetup]
    public async Task GlobalSetup()
    {
        var configuration = new DbInsertGuidBenchmarkServiceConfiguration(
            InitialDbRecordsNumberState,
            SetupActionChunkSize,
            RecordsPerBulkInsert);
        
        var serviceProvider = ServiceProviderFactory.CreateForDbInsertGuidBenchmark(configuration);
        var type = typeof(IDbInsertGuidBenchmarkService<>).MakeGenericType(EntityType.Value);
        _dbGuidBenchmarkService = (IDbInsertGuidBenchmarkService) serviceProvider.GetRequiredService(type);
        await _dbGuidBenchmarkService.GlobalSetup();
    }
    
    [GlobalCleanup]
    public async Task GlobalCleanup()
    {
        //await _dbGuidBenchmarkService.GlobalCleanup();
        _dbGuidBenchmarkService = null!;
    }
    
    [IterationSetup]
    public void IterationSetup()
    {
        _dbGuidBenchmarkService.IterationSetup().GetAwaiter().GetResult();
    }
    
    // [IterationCleanup]
    // public void IterationCleanup()
    // {
    //     _dbGuidBenchmarkService.IterationCleanup().GetAwaiter().GetResult();
    // }
    
    [Benchmark]
    [IterationCount(20)]
    public async Task SingleInsertLatencyBenchmark()
    {
        await _dbGuidBenchmarkService.SingleInsertLatencyBenchmark();
    }
    
    [Benchmark]
    [IterationCount(5)]
    public async Task BulkInsertLatencyBenchmark()
    {
        await _dbGuidBenchmarkService.BulkInsertLatencyBenchmark();
    }
    
    [Benchmark]
    [IterationCount(5)]
    public async Task BulkInsertOneByOneLatencyBenchmark()
    {
        await _dbGuidBenchmarkService.BulkInsertOneByOneLatencyBenchmark();
    }
}
