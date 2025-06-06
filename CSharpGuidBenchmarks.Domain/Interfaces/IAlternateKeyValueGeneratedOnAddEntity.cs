namespace CSharpGuidBenchmarks.Domain.Interfaces;

public interface IAlternateKeyValueGeneratedOnAddEntity<TAlternateKey> where TAlternateKey : struct
{
    public TAlternateKey AlternateKey { get; }
}