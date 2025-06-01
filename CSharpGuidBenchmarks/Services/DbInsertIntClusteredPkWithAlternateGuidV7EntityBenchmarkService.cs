// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertIntClusteredPkWithAlternateGuidV7EntityBenchmarkService : DbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV7Entity>
{
    private readonly Faker<IntClusteredPkWithAlternateGuidV7Entity> _faker = new Faker<IntClusteredPkWithAlternateGuidV7Entity>()
        .CustomInstantiator(f => IntClusteredPkWithAlternateGuidV7Entity.Create(f.Lorem.Sentence()));

    public DbInsertIntClusteredPkWithAlternateGuidV7EntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override IntClusteredPkWithAlternateGuidV7Entity GenerateEntity()
    {
        return _faker.Generate();
    }
}