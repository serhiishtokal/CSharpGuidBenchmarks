using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Domain.Interfaces;
using CSharpGuidBenchmarks.Extensions;

namespace Tests;

public class IsAssignableToGenericTypeTests
{
    [Fact]
    public void IsAssignableToGenericType_ShouldReturnTrue_ForGenericType()
    {
        // Arrange
        var type = typeof(GuidV7NonClusteredPkWithLongSeqClusteredEntity);
        
        // Act
        var result = type.IsAssignableToGenericType(typeof(IClusteredAkEntity<,>));
        
        // Assert
        Assert.True(result);
    }
}