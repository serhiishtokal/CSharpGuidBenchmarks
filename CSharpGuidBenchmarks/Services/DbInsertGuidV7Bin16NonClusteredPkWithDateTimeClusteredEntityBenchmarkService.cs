// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity>
{
    private readonly Faker<GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity> _faker = new Faker<GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity>()
        .CustomInstantiator(f => GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}