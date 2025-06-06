using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

public class GuidV7NonClusteredPkWithLongSeqClusteredEntity : AlternateKeyEntity<Guid, long>, IClusteredAkEntity<Guid, long>, IAlternateKeyValueGeneratedOnAddEntity<long>
{
    public GuidV7NonClusteredPkWithLongSeqClusteredEntity(Guid primaryKey, string payload, long alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static GuidV7NonClusteredPkWithLongSeqClusteredEntity Create(string payload)
    {
        return new GuidV7NonClusteredPkWithLongSeqClusteredEntity(Guid.NewGuid(), payload, 0);
    }
}