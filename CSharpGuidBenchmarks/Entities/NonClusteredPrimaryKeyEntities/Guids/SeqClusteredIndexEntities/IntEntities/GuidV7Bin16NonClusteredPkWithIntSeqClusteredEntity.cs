using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities.
    Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;

public class GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity : GuidNonClusteredPrimaryKeyWithIntSeqClusteredEntity
{
    private GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) :
        base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid.CreateVersion7(), payload, 0);
    }
}