using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

public class GuidV4NonClusteredPkWithLongSeqClusteredEntity : AlternateKeyEntity<Guid, long>, IClusteredAkEntity<Guid, long>, IAlternateKeyValueGeneratedOnAddEntity<long>
{
    public GuidV4NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV4NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV4NonClusteredPkWithLongSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
}