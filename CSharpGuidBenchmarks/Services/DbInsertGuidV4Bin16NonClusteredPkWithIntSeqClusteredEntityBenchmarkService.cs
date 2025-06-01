// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV4Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity>
{
    private readonly Faker<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity> _faker = new Faker<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV4Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}