namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities.Abstractions;

public abstract class GuidNonClusteredPrimaryKeyWithIntSeqClusteredEntity : NonClusteredPrimaryKeyWithIntSeqClusteredEntity<Guid>
{
    protected GuidNonClusteredPrimaryKeyWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
}