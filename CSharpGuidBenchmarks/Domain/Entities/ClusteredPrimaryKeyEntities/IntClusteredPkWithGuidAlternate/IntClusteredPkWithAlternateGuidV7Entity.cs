using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;

public class IntClusteredPkWithAlternateGuidV7Entity : AlternateKeyEntity<int, Guid>
{
    public IntClusteredPkWithAlternateGuidV7Entity(int primaryKey, string payload, Guid alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static IntClusteredPkWithAlternateGuidV7Entity Create(string payload)
    {
        return new IntClusteredPkWithAlternateGuidV7Entity(0, payload, Guid.CreateVersion7());
    }
}