namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;

public class GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity : AlternateKeyEntity<Guid, DateTime>, IClusteredAkEntity<Guid, DateTime>
{
    public GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid primaryKey, string payload, DateTime alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity Create(string payload)
    {
        return new GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity(Guid.CreateVersion7(), payload, DateTime.UtcNow);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}