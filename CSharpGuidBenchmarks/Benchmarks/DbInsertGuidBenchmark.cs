using BenchmarkDotNet.Attributes;
using CSharpGuidBenchmarks.Application.Others;
using CSharpGuidBenchmarks.Domain;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
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
    
    [ParamsSource(nameof(DbTypes))]
    public ParamWrapper<DbTypeEnum> DbType = null!;
    
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
    
    public static IEnumerable<ParamWrapper<DbTypeEnum>> DbTypes{
        get
        {
            yield return new ParamWrapper<DbTypeEnum>(DbTypeEnum.SqlServer, nameof(DbTypeEnum.SqlServer));
            yield return new ParamWrapper<DbTypeEnum>(DbTypeEnum.PostgreSql, nameof(DbTypeEnum.PostgreSql));
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
    
    
    protected IDbGuidInsertBenchmarkIterationService InsertBenchmarkIterationService = null!;
    protected static Type PrevEntityType = null!;

    [GlobalSetup]
    public async Task GlobalSetup()
    {
        var canSoftDbRespawn = EntityType.Value == PrevEntityType;
        var configuration = new DbGuidBenchmarkGlobalSetupConfiguration(
            DbType.Value,
            EntityType.Value,
            InitialDbRecordsNumberState,
            SetupActionChunkSize,
            RecordsPerBulkInsert,
            canSoftDbRespawn);
        
        var serviceProvider = ServiceProviderFactory.CreateForDbInsertGuidBenchmark(configuration);
        InsertBenchmarkIterationService = serviceProvider.GetRequiredService<IDbGuidInsertBenchmarkIterationService>();
        if (InsertBenchmarkIterationService is null)
        {
            throw new InvalidOperationException("Benchmark iteration service is not registered in the service provider.");
        }
        
        await InsertBenchmarkIterationService.GlobalSetup();
    }
    
    [GlobalCleanup]
    public async Task GlobalCleanup()
    {
        //await _dbGuidBenchmarkService.GlobalCleanup();
        InsertBenchmarkIterationService = null!;
        PrevEntityType = EntityType.Value;
    }
    
    [IterationSetup]
    public void IterationSetup()
    {
        InsertBenchmarkIterationService.IterationSetup().GetAwaiter().GetResult();
    }
    
    [IterationCleanup]
    public void IterationCleanup()
    {
        //_benchmarkIterationService.IterationCleanup().GetAwaiter().GetResult();
    }

    [IterationCleanup(Targets = [nameof(SingleInsertLatencyBenchmark)])]
    public void SingleInsertLatencyBenchmarkIterationCleanup()
    {
        InsertBenchmarkIterationService.SingleInsertLatencyBenchmarkIterationCleanup().GetAwaiter().GetResult();
    }

    [IterationCleanup(Targets = [nameof(BulkInsertLatencyBenchmark), nameof(BulkInsertOneByOneLatencyBenchmark)])]
    public void BulkInsertLatencyBenchmarkIterationCleanup()
    {
        InsertBenchmarkIterationService.BulkInsertLatencyBenchmarkIterationCleanup().GetAwaiter().GetResult();
    }
    
    [Benchmark]
    [IterationCount(20)]
    public async Task SingleInsertLatencyBenchmark()
    {
        await InsertBenchmarkIterationService.SingleInsertLatencyBenchmark();
    }
    
    [Benchmark]
    [IterationCount(5)]
    public async Task BulkInsertLatencyBenchmark()
    {
        await InsertBenchmarkIterationService.BulkInsertLatencyBenchmark();
    }
    
    [Benchmark]
    [IterationCount(5)]
    public async Task BulkInsertOneByOneLatencyBenchmark()
    {
        await InsertBenchmarkIterationService.BulkInsertOneByOneLatencyBenchmark();
    }
}