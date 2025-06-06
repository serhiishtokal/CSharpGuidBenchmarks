using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV7Bin16ClusteredPkEntity : Entity<Guid>
{
    private GuidV7Bin16ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV7Bin16ClusteredPkEntity Create(string payload)
    {
        return new GuidV7Bin16ClusteredPkEntity(Guid.CreateVersion7(), payload);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}