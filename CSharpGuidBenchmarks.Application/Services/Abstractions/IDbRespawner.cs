using Microsoft.EntityFrameworkCore.Metadata;

namespace CSharpGuidBenchmarks.Application.Services.Abstractions;

public interface IDbRespawner
{
    Task HardRespawnAsync();
    Task SoftRespawnAsync(params Type[] entityTypesToIgnore);
    Task SoftRespawnAsync(params IEntityType[] entityTypesToIgnore);
}