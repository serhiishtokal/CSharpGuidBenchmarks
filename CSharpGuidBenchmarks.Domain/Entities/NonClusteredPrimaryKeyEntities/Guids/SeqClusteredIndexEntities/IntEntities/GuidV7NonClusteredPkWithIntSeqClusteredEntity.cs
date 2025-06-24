using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.
    IntEntities;

public class GuidV7NonClusteredPkWithIntSeqClusteredEntity : AlternateKeyEntity<Guid, int>,
    IClusteredAkEntity<Guid, int>, IAlternateKeyValueGeneratedOnAddEntity<int>, ICreatable<GuidV7NonClusteredPkWithIntSeqClusteredEntity>
{
    public GuidV7NonClusteredPkWithIntSeqClusteredEntity(Guid primaryKey, string payload, int alternateKey) : base(
        primaryKey, payload, alternateKey)
    {
    }

    public static GuidV7NonClusteredPkWithIntSeqClusteredEntity Create(string payload)
    {
        return new GuidV7NonClusteredPkWithIntSeqClusteredEntity(Guid.CreateVersion7(), payload, 0);
    }
}