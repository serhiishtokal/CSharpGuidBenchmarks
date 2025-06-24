using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.
    IntEntities;

public class GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity : AlternateKeyEntity<Guid, int>,
    IClusteredAkEntity<Guid, int>, IAlternateKeyValueGeneratedOnAddEntity<int>, ICreatable<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity>
{
    public GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) : base(
        primaryKey, payload, alternateKey)
    {
    }

    public static GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity(Guid.CreateVersion7(), payload, 0);
    }

    [BinaryGuid] public override Guid PrimaryKey => base.PrimaryKey;
}