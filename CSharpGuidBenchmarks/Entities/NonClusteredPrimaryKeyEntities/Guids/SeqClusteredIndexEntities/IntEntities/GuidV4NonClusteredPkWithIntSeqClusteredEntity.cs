using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities.Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;

public class GuidV4NonClusteredPkWithIntSeqClusteredEntity : GuidNonClusteredPrimaryKeyWithIntSeqClusteredEntity
{
    private GuidV4NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) : base(
        primaryKey, payload, alternateKey)
    {
    }

    public static GuidV4NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV4NonClusteredPkWithIntSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
}