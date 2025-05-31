namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;

public class GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity : AlternateKeyEntity<Guid, int>,
    IClusteredAkEntity<Guid, int>, IAlternateKeyValueGeneratedOnAddEntity<int>
{
    public GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) : base(
        primaryKey, payload, alternateKey)
    {
    }

    public static GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }

    [BinaryGuid] public override Guid PrimaryKey => base.PrimaryKey;
}