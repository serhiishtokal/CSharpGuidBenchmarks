namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities.Abstractions;

public abstract class GuidNonClusteredPrimaryKeyWithLongSeqClusteredEntity : NonClusteredPrimaryKeyWithLongSeqClusteredEntity<Guid>
{
    protected GuidNonClusteredPrimaryKeyWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
}