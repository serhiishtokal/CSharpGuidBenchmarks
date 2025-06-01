// Auto-generated service based on template

using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

public class DbInsertGuidV7NonClusteredPkWithLongSeqClusteredEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV7NonClusteredPkWithLongSeqClusteredEntity>
{
    private readonly Faker<GuidV7NonClusteredPkWithLongSeqClusteredEntity> _faker = new Faker<GuidV7NonClusteredPkWithLongSeqClusteredEntity>()
        .CustomInstantiator(f => GuidV7NonClusteredPkWithLongSeqClusteredEntity.Create(f.Lorem.Sentence()));

    public DbInsertGuidV7NonClusteredPkWithLongSeqClusteredEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration)
        : base(dbContextFactory, configuration)
    {
    }

    protected override GuidV7NonClusteredPkWithLongSeqClusteredEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}