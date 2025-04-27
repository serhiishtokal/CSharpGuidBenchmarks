using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities;

[NotMapped]
public abstract class NonClusteredPrimaryKeyWithClusteredIndexEntity<TKey, TClusteredIndex> : Entity<TKey>, IClusteredIndexEntity<TClusteredIndex>, INonClusteredPrimaryKeyEntity<TKey> where TKey : struct where TClusteredIndex : struct
{
    protected NonClusteredPrimaryKeyWithClusteredIndexEntity(TKey primaryKey, string payload, TClusteredIndex alternateKey) : base(primaryKey, payload)
    {
        AlternateKey = alternateKey;
    }
    
    public TClusteredIndex AlternateKey { get; set; }
}


public interface INonClusteredPrimaryKeyEntity<TKey> : IEntity<TKey> where TKey : struct;

public interface IClusteredIndexEntity<TClusteredIndex> where TClusteredIndex : struct
{
    public TClusteredIndex AlternateKey { get; set; }
}