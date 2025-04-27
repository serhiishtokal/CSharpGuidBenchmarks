using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities.Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

public class GuidV7NonClusteredPkWithLongSeqClusteredEntity : GuidNonClusteredPrimaryKeyWithLongSeqClusteredEntity
{
    private GuidV7NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV7NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV7NonClusteredPkWithLongSeqClusteredEntity(Guid.CreateVersion7(), payload, 0);
    }
}