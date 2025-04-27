using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities.Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;

public class GuidV7NonClusteredPkWithIntSeqClusteredEntity : GuidNonClusteredPrimaryKeyWithIntSeqClusteredEntity
{
    private GuidV7NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV7NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV7NonClusteredPkWithIntSeqClusteredEntity(Guid.CreateVersion7(), payload, 0);
    }
}