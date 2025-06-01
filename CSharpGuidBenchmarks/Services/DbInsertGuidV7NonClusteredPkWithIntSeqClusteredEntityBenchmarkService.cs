// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7NonClusteredPkWithIntSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7NonClusteredPkWithIntSeqClusteredEntity>
{
    private readonly Faker<GuidV7NonClusteredPkWithIntSeqClusteredEntity> _faker = new Faker<GuidV7NonClusteredPkWithIntSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV7NonClusteredPkWithIntSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7NonClusteredPkWithIntSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7NonClusteredPkWithIntSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}