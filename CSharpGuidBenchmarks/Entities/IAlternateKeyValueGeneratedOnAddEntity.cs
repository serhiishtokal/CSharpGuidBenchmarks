namespace CSharpGuidBenchmarks.Entities;

public interface IAlternateKeyValueGeneratedOnAddEntity<TAlternateKey> where TAlternateKey : struct
{
    public TAlternateKey AlternateKey { get; }
}