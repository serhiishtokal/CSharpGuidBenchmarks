using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities.Abstractions;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;

public class GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity : GuidNonClusteredPrimaryKeyWithDateTimeSeqClusteredEntity
{
    private GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid primaryKey, string payload,
        DateTime alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity Create(string payload)
    {
        return new GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid.CreateVersion7(), payload,
            DateTime.UtcNow);
    }
}