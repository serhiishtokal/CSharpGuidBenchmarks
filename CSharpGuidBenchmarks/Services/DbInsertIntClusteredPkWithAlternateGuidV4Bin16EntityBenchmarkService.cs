// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertIntClusteredPkWithAlternateGuidV4Bin16EntityBenchmarkService : DbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV4Bin16Entity>
{
    private readonly Faker<IntClusteredPkWithAlternateGuidV4Bin16Entity> _faker = new Faker<IntClusteredPkWithAlternateGuidV4Bin16Entity>()
        .CustomInstantiator(f => IntClusteredPkWithAlternateGuidV4Bin16Entity.Create(f.Lorem.Sentence()));

    public DbInsertIntClusteredPkWithAlternateGuidV4Bin16EntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override IntClusteredPkWithAlternateGuidV4Bin16Entity GenerateEntity()
    {
        return _faker.Generate();
    }
}