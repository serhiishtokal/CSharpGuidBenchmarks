namespace CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV7ClusteredPkEntity : Entity<Guid>, IGuidPkEntity
{
    private GuidV7ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV7ClusteredPkEntity Create(string payload)
    {
        return new GuidV7ClusteredPkEntity(Guid.CreateVersion7(), payload);
    }
}