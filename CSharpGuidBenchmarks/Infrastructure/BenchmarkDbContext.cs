using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Domain.Interfaces;
using CSharpGuidBenchmarks.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Infrastructure;

public class BenchmarkDbContext : DbContext
{
    public BenchmarkDbContext(DbContextOptions<BenchmarkDbContext> options)
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
    //
    // // DateTime non clustered primary key entities
    public DbSet<GuidV4NonClusteredPkWithDateTimeClusteredEntity> GuidV4NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }
    public DbSet<GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity> GuidV4Bin16NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }
    public DbSet<GuidV7NonClusteredPkWithDateTimeClusteredEntity> GuidV7NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }
    public DbSet<GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity> GuidV7Bin16NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyAlternateKeyMapping();
        modelBuilder.ApplyClusteredAlternateKeyMapping();
        modelBuilder.ApplyAlternateKeyValueGeneratedOnAddMapping();
        modelBuilder.ApplyBinaryGuidMapping();
    }
}

public static class ModelBuilderExtensions
{
    public static void ApplyBinaryGuidMapping(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var prop in entity.GetProperties())
            {
                if (prop.ClrType == typeof(Guid) &&
                    prop.PropertyInfo?.IsDefined(typeof(BinaryGuidAttribute), inherit: true) == true)
                {
                    prop.SetColumnType("binary(16)");
                }
            }
        }
    }
    
    public static void ApplyAlternateKeyMapping(this ModelBuilder modelBuilder)
    {
        var entityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(t => t.ClrType.IsAssignableToGenericType(typeof(AlternateKeyEntity<,>)));

        foreach (var entityType in entityTypes)
        {
            var entityBuilder = modelBuilder.Entity(entityType.ClrType);
            entityBuilder.HasAlternateKey(nameof(AlternateKeyEntity<bool,bool>.AlternateKey));
        }
    }
    
    public static void ApplyClusteredAlternateKeyMapping(this ModelBuilder modelBuilder)
    {
        var entityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(t => t.ClrType.IsAssignableToGenericType(typeof(IClusteredAkEntity<,>)));

        foreach (var entityType in entityTypes)
        {
            var entityBuilder = modelBuilder.Entity(entityType.ClrType);
            entityBuilder.HasAlternateKey(nameof(IClusteredAkEntity<bool,bool>.AlternateKey))
                .IsClustered();
            
            entityBuilder.HasKey(nameof(IClusteredAkEntity<bool, bool>.PrimaryKey))
                .IsClustered(false);
        }
    }
    
    public static void ApplyAlternateKeyValueGeneratedOnAddMapping(this ModelBuilder modelBuilder)
    {
        var entityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(t => t.ClrType.IsAssignableToGenericType(typeof(IAlternateKeyValueGeneratedOnAddEntity<>)));

        foreach (var entityType in entityTypes)
        {
            var entityBuilder = modelBuilder.Entity(entityType.ClrType);
            var property = entityBuilder.Property(nameof(IAlternateKeyValueGeneratedOnAddEntity<bool>.AlternateKey));
            property.ValueGeneratedOnAdd();
            var isDateTime = entityType.ClrType.GetInterfaces().Any(x=>x ==typeof(IAlternateKeyValueGeneratedOnAddEntity<DateTime>));
            if (isDateTime)
            {
                property.HasDefaultValueSql("GETUTCDATE()");
            }
            

        }
    }
}