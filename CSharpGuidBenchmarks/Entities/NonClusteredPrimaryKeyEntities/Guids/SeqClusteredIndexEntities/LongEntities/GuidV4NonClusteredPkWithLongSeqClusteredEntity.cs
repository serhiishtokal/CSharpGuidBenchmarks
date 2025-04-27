using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities.Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

public class GuidV4NonClusteredPkWithLongSeqClusteredEntity : GuidNonClusteredPrimaryKeyWithLongSeqClusteredEntity
{
    private GuidV4NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) :
        base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV4NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV4NonClusteredPkWithLongSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
}