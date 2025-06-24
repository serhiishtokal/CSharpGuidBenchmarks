using Bogus;
using CSharpGuidBenchmarks.Domain.Abstractions;

namespace CSharpGuidBenchmarks.Application.Services.EntityFactories;

public class EntityFakerProvider<T> : IEntityFakerProvider<T>
    where T : class, ICreatable<T>
{
    public Faker<T> Faker { get; } = new Faker<T>().CustomInstantiator(f => T.Create(f.Lorem.Sentence()));
}