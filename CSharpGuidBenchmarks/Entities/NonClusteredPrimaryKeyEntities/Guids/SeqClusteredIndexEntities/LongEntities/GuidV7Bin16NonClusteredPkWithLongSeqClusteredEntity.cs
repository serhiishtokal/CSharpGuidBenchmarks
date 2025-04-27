using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities.
    Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

public class GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity : GuidNonClusteredPrimaryKeyWithLongSeqClusteredEntity
{
    private GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) :
        base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid.CreateVersion7(), payload, 0);
    }
}