using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities.Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;

public class GuidV7NonClusteredPkWithDateTimeClusteredEntity : GuidNonClusteredPrimaryKeyWithDateTimeSeqClusteredEntity
{
    private GuidV7NonClusteredPkWithDateTimeClusteredEntity(Guid primaryKey, string payload,
        DateTime alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV7NonClusteredPkWithDateTimeClusteredEntity Create(string payload)
    {
        return new GuidV7NonClusteredPkWithDateTimeClusteredEntity(Guid.CreateVersion7(), payload, DateTime.UtcNow);
    }
}