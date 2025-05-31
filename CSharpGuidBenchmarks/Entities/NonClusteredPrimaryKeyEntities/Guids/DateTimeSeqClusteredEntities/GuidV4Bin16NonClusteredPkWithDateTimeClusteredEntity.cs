namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;

public class GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity : AlternateKeyEntity<Guid, DateTime>, IClusteredAkEntity<Guid, DateTime>
{
    public GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid primaryKey, string payload, DateTime alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity Create(string payload)
    {
        return new GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid.NewGuid(), payload, DateTime.UtcNow);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}