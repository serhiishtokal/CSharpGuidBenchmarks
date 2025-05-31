namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

public class GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity : AlternateKeyEntity<Guid, long>, IClusteredAkEntity<Guid, long>
{
    public GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}