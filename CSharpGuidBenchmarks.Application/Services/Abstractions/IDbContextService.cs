namespace CSharpGuidBenchmarks.Application.Services.Abstractions;

public interface IDbContextService<TEntity>
{
    Task RespawnDbAsync();
    Task RespawnDbAsync(params Type[] excludeEntities);
    Task EnsureExactRecordCountSetupAsync(int initialDbRecordsNumberState);
}