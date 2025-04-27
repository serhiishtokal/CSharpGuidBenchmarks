using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities.
    Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;

public class GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity : GuidNonClusteredPrimaryKeyWithIntSeqClusteredEntity
{
    private GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) :
        base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
}