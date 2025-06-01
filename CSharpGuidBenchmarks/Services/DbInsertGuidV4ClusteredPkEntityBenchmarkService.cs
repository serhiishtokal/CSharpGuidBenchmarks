// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV4ClusteredPkEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4ClusteredPkEntity>
{
    private readonly Faker<GuidV4ClusteredPkEntity> _faker = new Faker<GuidV4ClusteredPkEntity>()
        .CustomInstantiator(f => GuidV4ClusteredPkEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV4ClusteredPkEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV4ClusteredPkEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}