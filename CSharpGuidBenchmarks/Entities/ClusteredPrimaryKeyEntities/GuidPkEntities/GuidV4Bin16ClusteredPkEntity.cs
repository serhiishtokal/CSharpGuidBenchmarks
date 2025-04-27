namespace CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;

public class GuidV4Bin16ClusteredPkEntity : Entity<Guid>, IGuidPkEntity
{
    private GuidV4Bin16ClusteredPkEntity(Guid primaryKey, string payload) : base(primaryKey, payload)
    {
    }
    
    public static GuidV4Bin16ClusteredPkEntity Create(string payload)
    {
        return new GuidV4Bin16ClusteredPkEntity(Guid.NewGuid(), payload);
    }
    
    [BinaryGuid]
    public override Guid PrimaryKey => base.PrimaryKey;
}