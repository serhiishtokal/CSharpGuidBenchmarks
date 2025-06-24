using CSharpGuidBenchmarks.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Application.Others;

public interface IDbGuidBenchmarkIterationService
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

public interface IDbGuidBenchmarkIterationService<TEntity, TDbContext> : IDbGuidBenchmarkIterationService
    where TEntity : class, ICreatable<TEntity>
    where TDbContext : DbContext;