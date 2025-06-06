using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;

public class GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity : AlternateKeyEntity<Guid, DateTime>,
    IClusteredAkEntity<Guid, DateTime>, IAlternateKeyValueGeneratedOnAddEntity<DateTime>
{
    public GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid primaryKey, string payload, DateTime alternateKey)
        : base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity Create(string payload)
    {
        return new GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid.CreateVersion7(), payload, default);
    }

    [BinaryGuid] public override Guid PrimaryKey => base.PrimaryKey;
}