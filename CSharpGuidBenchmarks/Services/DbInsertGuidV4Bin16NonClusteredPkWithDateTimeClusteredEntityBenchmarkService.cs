// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV4Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity>
{
    private readonly Faker<GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity> _faker = new Faker<GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity>()
        .CustomInstantiator(f => GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV4Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}