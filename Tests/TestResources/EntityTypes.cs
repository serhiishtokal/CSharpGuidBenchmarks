using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;

namespace Tests.TestResources;

public class EntityConstants
{
    public static IEnumerable<Type> EntityTypes =
    [
        typeof(GuidV4Bin16ClusteredPkEntity),
        typeof(GuidV4ClusteredPkEntity),
        typeof(GuidV7Bin16ClusteredPkEntity),
        typeof(GuidV7ClusteredPkEntity),
        
        typeof(IntClusteredPkEntity),
        
        typeof(IntClusteredPkWithAlternateGuidV4Bin16Entity),
        typeof(IntClusteredPkWithAlternateGuidV4Entity),
        typeof(IntClusteredPkWithAlternateGuidV7Bin16Entity),
        typeof(IntClusteredPkWithAlternateGuidV7Entity),
        
        typeof(GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity),
        typeof(GuidV4NonClusteredPkWithDateTimeClusteredEntity),
        typeof(GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity),
        typeof(GuidV7NonClusteredPkWithDateTimeClusteredEntity),
        
        typeof(GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity),
        typeof(GuidV4NonClusteredPkWithIntSeqClusteredEntity),
        typeof(GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity),
        typeof(GuidV7NonClusteredPkWithIntSeqClusteredEntity),
        
        typeof(GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity),
        typeof(GuidV4NonClusteredPkWithLongSeqClusteredEntity),
        typeof(GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity),
        typeof(GuidV7NonClusteredPkWithLongSeqClusteredEntity),
    ];
}