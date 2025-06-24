using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Application.Services;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>(string name)
        where TEntity : class;

    DbSet<TEntity> Set<TEntity>()
        where TEntity : class;
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}