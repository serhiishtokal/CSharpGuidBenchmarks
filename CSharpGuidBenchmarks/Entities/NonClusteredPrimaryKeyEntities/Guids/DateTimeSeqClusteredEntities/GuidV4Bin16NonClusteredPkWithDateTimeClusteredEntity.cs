namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;

public class GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity : AlternateKeyEntity<Guid, DateTime>,
    IClusteredAkEntity<Guid, DateTime>, IAlternateKeyValueGeneratedOnAddEntity<DateTime>
{
    public GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid primaryKey, string payload, DateTime alternateKey)
        : base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity Create(string payload)
    {
        return new GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid.NewGuid(), payload, default);
    }

    [BinaryGuid] public override Guid PrimaryKey => base.PrimaryKey;
}