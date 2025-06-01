// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertIntClusteredPkWithAlternateGuidV7Bin16EntityBenchmarkService : DbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV7Bin16Entity>
{
    private readonly Faker<IntClusteredPkWithAlternateGuidV7Bin16Entity> _faker = new Faker<IntClusteredPkWithAlternateGuidV7Bin16Entity>()
        .CustomInstantiator(f => IntClusteredPkWithAlternateGuidV7Bin16Entity.Create(f.Lorem.Sentence()));

    public DbInsertIntClusteredPkWithAlternateGuidV7Bin16EntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override IntClusteredPkWithAlternateGuidV7Bin16Entity GenerateEntity()
    {
        return _faker.Generate();
    }
}