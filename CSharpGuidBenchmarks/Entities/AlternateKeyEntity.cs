namespace CSharpGuidBenchmarks.Entities;

public abstract class AlternateKeyEntity<TKey, TAlternateKey> : Entity<TKey>
    where TKey : struct where TAlternateKey : struct
{
    protected AlternateKeyEntity(TKey primaryKey, string payload, TAlternateKey alternateKey) : base(primaryKey,
        payload)
    {
        AlternateKey = alternateKey;
    }

    public virtual TAlternateKey AlternateKey { get; }
}