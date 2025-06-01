// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV4NonClusteredPkWithDateTimeClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4NonClusteredPkWithDateTimeClusteredEntity>
{
    private readonly Faker<GuidV4NonClusteredPkWithDateTimeClusteredEntity> _faker = new Faker<GuidV4NonClusteredPkWithDateTimeClusteredEntity>()
        .CustomInstantiator(f => GuidV4NonClusteredPkWithDateTimeClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV4NonClusteredPkWithDateTimeClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV4NonClusteredPkWithDateTimeClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}