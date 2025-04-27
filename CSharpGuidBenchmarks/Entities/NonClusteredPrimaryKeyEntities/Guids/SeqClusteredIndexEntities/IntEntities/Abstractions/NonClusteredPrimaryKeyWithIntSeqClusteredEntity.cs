namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities.Abstractions;

public abstract class NonClusteredPrimaryKeyWithIntSeqClusteredEntity<TKey> : NonClusteredPrimaryKeyWithClusteredIndexEntity<TKey, int> where TKey : struct
{
    protected NonClusteredPrimaryKeyWithIntSeqClusteredEntity(TKey primaryKey, string payload, int alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
}