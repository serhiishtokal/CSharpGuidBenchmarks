using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV4Bin16ClusteredPkEntity : Entity<Guid>, ICreatable<GuidV4Bin16ClusteredPkEntity>
{
    private GuidV4Bin16ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV4Bin16ClusteredPkEntity Create(string payload)
    {
        return new GuidV4Bin16ClusteredPkEntity(Guid.NewGuid(), payload);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}