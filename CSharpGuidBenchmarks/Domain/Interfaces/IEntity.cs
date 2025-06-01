namespace CSharpGuidBenchmarks.Domain.Interfaces;

public interface IEntity<T> where T : struct
{
    T PrimaryKey { get; }
    string Payload { get; }
}