using CSharpGuidBenchmarks.Application.Services;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Infrastructure.SqlServer.DbContexts;

public class SqlServerDbContext : DbContext, ISqlServerDbContext
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<IntClusteredPkEntity> IntClusteredPrimaryKeyEntities { get; set; }
    public DbSet<GuidV4ClusteredPkEntity> GuidV4ClusteredPkEntities { get; set; }
    public DbSet<GuidV4Bin16ClusteredPkEntity> GuidV4Bin16ClusteredPkEntities { get; set; }
    public DbSet<GuidV7ClusteredPkEntity> GuidV7ClusteredPkEntities { get; set; }
    public DbSet<GuidV7Bin16ClusteredPkEntity> GuidV7Bin16ClusteredPkEntities { get; set; }
    
    public DbSet<IntClusteredPkWithAlternateGuidV4Entity> IntClusteredPkWithAlternateGuidV4Entities { get; set; }
    public DbSet<IntClusteredPkWithAlternateGuidV4Bin16Entity> IntClusteredPkWithAlternateGuidV4Bin16Entities { get; set; }
    public DbSet<IntClusteredPkWithAlternateGuidV7Entity> IntClusteredPkWithAlternateGuidV7Entities { get; set; }
    public DbSet<IntClusteredPkWithAlternateGuidV7Bin16Entity> IntClusteredPkWithAlternateGuidV7Bin16Entities { get; set; }
    
    // int non-clustered primary key entities 
    public DbSet<GuidV4NonClusteredPkWithIntSeqClusteredEntity> GuidV4NonClusteredPkWithIntSeqClusteredEntities { get; set; }
    public DbSet<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity> GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntities { get; set; }
    public DbSet<GuidV7NonClusteredPkWithIntSeqClusteredEntity> GuidV7NonClusteredPkWithIntSeqClusteredEntities { get; set; }
    public DbSet<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity> GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntities { get; set; }
    //
    // // long non clustered primary key entities 
    public DbSet<GuidV4NonClusteredPkWithLongSeqClusteredEntity> GuidV4NonClusteredPkWithLongSeqClusteredEntities { get; set; }
    public DbSet<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity> GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities { get; set; }
    public DbSet<GuidV7NonClusteredPkWithLongSeqClusteredEntity> GuidV7NonClusteredPkWithLongSeqClusteredEntities { get; set; }
    public DbSet<GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity> GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyAlternateKeyMapping();
        modelBuilder.ApplyClusteredAlternateKeyMapping();
        modelBuilder.ApplyAlternateKeyValueGeneratedOnAddMapping();
        modelBuilder.ApplyBinaryGuidMapping();
    }
}