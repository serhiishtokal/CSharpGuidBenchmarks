namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities.Abstractions;

public abstract class NonClusteredPrimaryKeyWithDateTimeSeqClusteredEntity<TKey> : NonClusteredPrimaryKeyWithClusteredIndexEntity<TKey, DateTime> where TKey : struct
{
    protected NonClusteredPrimaryKeyWithDateTimeSeqClusteredEntity(TKey primaryKey, string payload, DateTime alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
}