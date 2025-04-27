namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities.Abstractions;

public abstract class GuidNonClusteredPrimaryKeyWithDateTimeSeqClusteredEntity : NonClusteredPrimaryKeyWithDateTimeSeqClusteredEntity<Guid>
{
    protected GuidNonClusteredPrimaryKeyWithDateTimeSeqClusteredEntity(Guid primaryKey, string payload, DateTime alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
}