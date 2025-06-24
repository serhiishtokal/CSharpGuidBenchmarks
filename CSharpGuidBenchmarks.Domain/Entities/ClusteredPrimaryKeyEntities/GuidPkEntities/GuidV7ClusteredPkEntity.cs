using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV7ClusteredPkEntity : Entity<Guid>, ICreatable<GuidV7ClusteredPkEntity>
{
    private GuidV7ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV7ClusteredPkEntity Create(string payload)
    {
        return new GuidV7ClusteredPkEntity(Guid.CreateVersion7(), payload);
    }
}