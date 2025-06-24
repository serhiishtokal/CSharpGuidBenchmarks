using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;

public class IntClusteredPkEntity : Entity<int>, ICreatable<IntClusteredPkEntity>
{
    private IntClusteredPkEntity(int primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static IntClusteredPkEntity Create(string payload)
    {
        return new IntClusteredPkEntity(0, payload);
    }
}