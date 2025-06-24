using Bogus;
using CSharpGuidBenchmarks.Domain.Abstractions;

namespace CSharpGuidBenchmarks.Application.Services.EntityFactories;

public interface IEntityFakerProvider<T>
    where T : class, ICreatable<T>
{
    Faker<T> Faker { get; }
}