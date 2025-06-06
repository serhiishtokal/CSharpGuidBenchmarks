namespace CSharpGuidBenchmarks.Domain.Interfaces;

public interface IEntity<T>: IEntity where T : struct
{
    T PrimaryKey { get; }
    string Payload { get; }
}

public interface IEntity;
