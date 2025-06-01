// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7ClusteredPkEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7ClusteredPkEntity>
{
    private readonly Faker<GuidV7ClusteredPkEntity> _faker = new Faker<GuidV7ClusteredPkEntity>()
        .CustomInstantiator(f => GuidV7ClusteredPkEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7ClusteredPkEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7ClusteredPkEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}