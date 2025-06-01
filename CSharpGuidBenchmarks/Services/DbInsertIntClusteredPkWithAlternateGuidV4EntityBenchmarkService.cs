// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertIntClusteredPkWithAlternateGuidV4EntityBenchmarkService : DbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV4Entity>
{
    private readonly Faker<IntClusteredPkWithAlternateGuidV4Entity> _faker = new Faker<IntClusteredPkWithAlternateGuidV4Entity>()
        .CustomInstantiator(f => IntClusteredPkWithAlternateGuidV4Entity.Create(f.Lorem.Sentence()));

    public DbInsertIntClusteredPkWithAlternateGuidV4EntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override IntClusteredPkWithAlternateGuidV4Entity GenerateEntity()
    {
        return _faker.Generate();
    }
}