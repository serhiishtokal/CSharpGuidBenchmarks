// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7NonClusteredPkWithDateTimeClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7NonClusteredPkWithDateTimeClusteredEntity>
{
    private readonly Faker<GuidV7NonClusteredPkWithDateTimeClusteredEntity> _faker = new Faker<GuidV7NonClusteredPkWithDateTimeClusteredEntity>()
        .CustomInstantiator(f => GuidV7NonClusteredPkWithDateTimeClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7NonClusteredPkWithDateTimeClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7NonClusteredPkWithDateTimeClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}