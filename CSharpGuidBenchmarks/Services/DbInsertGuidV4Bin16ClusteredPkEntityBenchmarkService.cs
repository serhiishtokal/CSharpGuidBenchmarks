using Bogus;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Infrastructure;
using CSharpGuidBenchmarks.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Services;

// DbInsertGuidV4Bin16ClusteredPkEntityBenchmarkService 
// DbInsertGuidV4ClusteredPkEntityBenchmarkService 
// DbInsertGuidV7Bin16ClusteredPkEntityBenchmarkService 
// DbInsertGuidV7ClusteredPkEntityBenchmarkService 
// DbInsertIntClusteredPkEntityBenchmarkService 
// DbInsertIntClusteredPkWithAlternateGuidV4Bin16EntityBenchmarkService 
// DbInsertIntClusteredPkWithAlternateGuidV4EntityBenchmarkService 
// DbInsertIntClusteredPkWithAlternateGuidV7Bin16EntityBenchmarkService 
// DbInsertIntClusteredPkWithAlternateGuidV7EntityBenchmarkService 
// DbInsertGuidV4Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService 
// DbInsertGuidV4NonClusteredPkWithDateTimeClusteredEntityBenchmarkService 
// DbInsertGuidV7Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService 
// DbInsertGuidV7NonClusteredPkWithDateTimeClusteredEntityBenchmarkService 
// DbInsertGuidV4Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService 
// DbInsertGuidV4NonClusteredPkWithIntSeqClusteredEntityBenchmarkService 
// DbInsertGuidV7Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService 
// DbInsertGuidV7NonClusteredPkWithIntSeqClusteredEntityBenchmarkService 
// DbInsertGuidV4Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService 
// DbInsertGuidV4NonClusteredPkWithLongSeqClusteredEntityBenchmarkService 
// DbInsertGuidV7Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService 
// DbInsertGuidV7NonClusteredPkWithLongSeqClusteredEntityBenchmarkService 

public class DbInsertGuidV4Bin16ClusteredPkEntityBenchmarkService : DbInsertGuidBenchmarkService<GuidV4Bin16ClusteredPkEntity>
{
    private readonly Faker<GuidV4Bin16ClusteredPkEntity> _faker = new Faker<GuidV4Bin16ClusteredPkEntity>()
        .CustomInstantiator(f => GuidV4Bin16ClusteredPkEntity.Create(f.Lorem.Sentence()));
    
    public DbInsertGuidV4Bin16ClusteredPkEntityBenchmarkService(
        IDbContextFactory<BenchmarkDbContext> dbContextFactory,
        DbInsertGuidBenchmarkServiceConfiguration configuration) 
        : base(dbContextFactory, configuration)
    {
       
    }

    protected override GuidV4Bin16ClusteredPkEntity GenerateEntity()
    {
        return _faker.Generate();
    }
}