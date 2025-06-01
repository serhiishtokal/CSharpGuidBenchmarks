// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7Bin16ClusteredPkEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7Bin16ClusteredPkEntity>
{
    private readonly Faker<GuidV7Bin16ClusteredPkEntity> _faker = new Faker<GuidV7Bin16ClusteredPkEntity>()
        .CustomInstantiator(f => GuidV7Bin16ClusteredPkEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7Bin16ClusteredPkEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7Bin16ClusteredPkEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}