namespace CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities;

public class IntClusteredPkEntity : Entity<int>
{
    private IntClusteredPkEntity(int primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static IntClusteredPkEntity Create(string payload)
    {
        return new IntClusteredPkEntity(0, payload);
    }
}