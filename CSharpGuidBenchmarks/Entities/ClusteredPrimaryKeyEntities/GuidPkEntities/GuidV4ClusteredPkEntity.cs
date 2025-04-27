namespace CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV4ClusteredPkEntity : Entity<Guid>, IGuidPkEntity
{
    private GuidV4ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV4ClusteredPkEntity Create(string payload)
    {
        return new GuidV4ClusteredPkEntity(Guid.NewGuid(), payload);
    }
}