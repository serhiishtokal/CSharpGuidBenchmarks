using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;

public class GuidV4NonClusteredPkWithDateTimeClusteredEntity : AlternateKeyEntity<Guid, DateTime>,
    IClusteredAkEntity<Guid, DateTime>, IAlternateKeyValueGeneratedOnAddEntity<DateTime>
{
    public GuidV4NonClusteredPkWithDateTimeClusteredEntity(Guid primaryKey, string payload, DateTime alternateKey) :
        base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV4NonClusteredPkWithDateTimeClusteredEntity Create(string payload)
    {
        return new GuidV4NonClusteredPkWithDateTimeClusteredEntity(Guid.NewGuid(), payload, default);
    }
}