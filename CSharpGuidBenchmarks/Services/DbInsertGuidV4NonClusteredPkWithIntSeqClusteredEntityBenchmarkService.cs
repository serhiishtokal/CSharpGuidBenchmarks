// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV4NonClusteredPkWithIntSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4NonClusteredPkWithIntSeqClusteredEntity>
{
    private readonly Faker<GuidV4NonClusteredPkWithIntSeqClusteredEntity> _faker = new Faker<GuidV4NonClusteredPkWithIntSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV4NonClusteredPkWithIntSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV4NonClusteredPkWithIntSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV4NonClusteredPkWithIntSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}