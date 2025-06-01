// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity>
{
    private readonly Faker<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity> _faker = new Faker<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}