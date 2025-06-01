// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertIntClusteredPkEntityBenchmarkService : DbInsertGuidBenchmarkService<IntClusteredPkEntity>
{
    private readonly Faker<IntClusteredPkEntity> _faker = new Faker<IntClusteredPkEntity>()
        .CustomInstantiator(f => IntClusteredPkEntity.Create(f.Lorem.Sentence()));

    public DbInsertIntClusteredPkEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override IntClusteredPkEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}