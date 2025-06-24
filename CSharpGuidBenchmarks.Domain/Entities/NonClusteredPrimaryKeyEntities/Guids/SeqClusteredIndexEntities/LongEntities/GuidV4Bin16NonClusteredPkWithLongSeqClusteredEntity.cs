using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.
    LongEntities;

public class GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity : AlternateKeyEntity<Guid, long>,
    IClusteredAkEntity<Guid, long>, IAlternateKeyValueGeneratedOnAddEntity<long>, ICreatable<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity>
{
    public GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) :
        base(primaryKey, payload, alternateKey)
    {
    }

    public static GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }

    [BinaryGuid] public override Guid PrimaryKey => base.PrimaryKey;
}