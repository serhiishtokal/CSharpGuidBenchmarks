namespace CSharpGuidBenchmarks.Entities;

public interface IEntity<T> where T : struct
{
    T PrimaryKey { get; }
    string Payload { get; }
}