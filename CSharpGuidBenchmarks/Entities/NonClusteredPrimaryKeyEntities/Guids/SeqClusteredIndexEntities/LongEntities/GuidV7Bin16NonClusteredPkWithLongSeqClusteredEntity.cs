namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

public class GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity : AlternateKeyEntity<Guid, long>, IClusteredAkEntity<Guid, long>
{
    public GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}