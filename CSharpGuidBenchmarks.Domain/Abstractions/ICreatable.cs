namespace CSharpGuidBenchmarks.Domain.Abstractions;

public interface ICreatable<out TSelf>
    where TSelf : class, ICreatable<TSelf>
{
    static abstract TSelf Create(string payload);
}