namespace CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;

public class IntClusteredPkWithAlternateGuidV4Entity : AlternateKeyEntity<int, Guid>, IGuidAkEntity
{
    public IntClusteredPkWithAlternateGuidV4Entity(int primaryKey, string payload, Guid alternateKey) : base(primaryKey, payload, alternateKey)
    {
    }
    
    public static IntClusteredPkWithAlternateGuidV4Entity Create(string payload)
    {
        return new IntClusteredPkWithAlternateGuidV4Entity(0, payload, Guid.NewGuid());
    }
}