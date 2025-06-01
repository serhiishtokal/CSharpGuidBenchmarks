// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV4NonClusteredPkWithLongSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4NonClusteredPkWithLongSeqClusteredEntity>
{
    private readonly Faker<GuidV4NonClusteredPkWithLongSeqClusteredEntity> _faker = new Faker<GuidV4NonClusteredPkWithLongSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV4NonClusteredPkWithLongSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV4NonClusteredPkWithLongSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV4NonClusteredPkWithLongSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}