using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;

public class IntClusteredPkWithAlternateGuidV4Bin16Entity : AlternateKeyEntity<int, Guid>
{
    public IntClusteredPkWithAlternateGuidV4Bin16Entity(int primaryKey, string payload, Guid alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static IntClusteredPkWithAlternateGuidV4Bin16Entity Create(string payload)
    {
        return new IntClusteredPkWithAlternateGuidV4Bin16Entity(0, payload, Guid.NewGuid());
    }
    
    [BinaryGuid]
    public override Guid AlternateKey => base.AlternateKey;
}