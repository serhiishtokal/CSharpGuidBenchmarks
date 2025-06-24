using CSharpGuidBenchmarks.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Application.Others;

public interface IDbGuidInsertBenchmarkIterationService
{
    Task GlobalSetup();
    Task GlobalCleanup();
    Task IterationSetup();
    Task IterationCleanup();
    Task SingleInsertLatencyBenchmark();
    Task BulkInsertLatencyBenchmark();
    Task BulkInsertOneByOneLatencyBenchmark();
    Task SingleInsertLatencyBenchmarkIterationCleanup();
    Task BulkInsertLatencyBenchmarkIterationCleanup();
}

public interface IDbGuidInsertBenchmarkIterationService<TEntity, TDbContext> : IDbGuidInsertBenchmarkIterationService
    where TEntity : class, ICreatable<TEntity>
    where TDbContext : DbContext;