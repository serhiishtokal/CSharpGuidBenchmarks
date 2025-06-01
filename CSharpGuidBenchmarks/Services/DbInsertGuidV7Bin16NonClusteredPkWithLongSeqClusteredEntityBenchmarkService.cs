// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity>
{
    private readonly Faker<GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity> _faker = new Faker<GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}