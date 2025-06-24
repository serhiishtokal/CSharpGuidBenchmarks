namespace CSharpGuidBenchmarks.Application.Services.Abstractions;

public interface IDbInsertGuidBenchmarkService
{
    Task GlobalSetup();
    Task IterationSetup();
    Task SingleInsertLatencyBenchmark();
    Task BulkInsertLatencyBenchmark();
    //Task IterationCleanup();
    //Task GlobalCleanup();
    Task BulkInsertOneByOneLatencyBenchmark();
}

public interface IDbInsertGuidBenchmarkService<TEntity>: IDbInsertGuidBenchmarkService where TEntity : class;