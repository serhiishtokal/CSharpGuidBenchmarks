using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;

public class IntClusteredPkWithAlternateGuidV4Entity : AlternateKeyEntity<int, Guid>
{
    public IntClusteredPkWithAlternateGuidV4Entity(int primaryKey, string payload, Guid alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static IntClusteredPkWithAlternateGuidV4Entity Create(string payload)
    {
        return new IntClusteredPkWithAlternateGuidV4Entity(0, payload, Guid.NewGuid());
    }
}