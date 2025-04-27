namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities.Abstractions;

public abstract class NonClusteredPrimaryKeyWithLongSeqClusteredEntity<TKey> : NonClusteredPrimaryKeyWithClusteredIndexEntity<TKey, long>, INonClusteredPrimaryKeyEntity<TKey> where TKey : struct
{
    protected NonClusteredPrimaryKeyWithLongSeqClusteredEntity(TKey primaryKey, string payload, long alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
}