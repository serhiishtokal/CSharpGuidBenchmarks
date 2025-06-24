using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV4ClusteredPkEntity : Entity<Guid>, ICreatable<GuidV4ClusteredPkEntity>
{
    private GuidV4ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV4ClusteredPkEntity Create(string payload)
    {
        return new GuidV4ClusteredPkEntity(Guid.NewGuid(), payload);
    }
}