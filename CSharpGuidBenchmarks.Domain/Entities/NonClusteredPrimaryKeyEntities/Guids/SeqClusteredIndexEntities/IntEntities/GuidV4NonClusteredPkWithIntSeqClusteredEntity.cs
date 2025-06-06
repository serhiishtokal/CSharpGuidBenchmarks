using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;

public class GuidV4NonClusteredPkWithIntSeqClusteredEntity : AlternateKeyEntity<Guid, int>, IClusteredAkEntity<Guid, int>, IAlternateKeyValueGeneratedOnAddEntity<int>
{
    public GuidV4NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV4NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV4NonClusteredPkWithIntSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
}