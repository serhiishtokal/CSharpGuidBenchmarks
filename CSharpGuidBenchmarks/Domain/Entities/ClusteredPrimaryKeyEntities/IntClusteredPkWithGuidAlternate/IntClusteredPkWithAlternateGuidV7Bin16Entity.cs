using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;

public class IntClusteredPkWithAlternateGuidV7Bin16Entity : AlternateKeyEntity<int, Guid>
{
    public IntClusteredPkWithAlternateGuidV7Bin16Entity(int primaryKey, string payload, Guid alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static IntClusteredPkWithAlternateGuidV7Bin16Entity Create(string payload)
    {
        return new IntClusteredPkWithAlternateGuidV7Bin16Entity(0, payload, Guid.CreateVersion7());
    }

    [BinaryGuid]
    public override Guid AlternateKey => base.AlternateKey;
}