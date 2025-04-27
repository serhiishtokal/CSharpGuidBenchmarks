namespace CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV7Bin16ClusteredPkEntity : Entity<Guid>, IGuidPkEntity
{
    private GuidV7Bin16ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV7Bin16ClusteredPkEntity Create(string payload)
    {
        return new GuidV7Bin16ClusteredPkEntity(Guid.CreateVersion7(), payload);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}