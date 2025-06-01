// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV4Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity>
{
    private readonly Faker<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity> _faker = new Faker<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV4Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}