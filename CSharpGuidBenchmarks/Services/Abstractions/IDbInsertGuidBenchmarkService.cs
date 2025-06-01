namespace CSharpGuidBenchmarks.Services.Abstractions;

public interface IDbInsertGuidBenchmarkService
{
    Task GlobalSetup();
    Task IterationSetup();
    Task SingleInsertLatencyBenchmark();
    Task BulkInsertLatencyBenchmark();
    Task IterationCleanup();
}

public interface IDbInsertGuidBenchmarkService<TEntity>: IDbInsertGuidBenchmarkService where TEntity : class;