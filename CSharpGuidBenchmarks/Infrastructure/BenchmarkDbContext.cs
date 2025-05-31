using System.Reflection;
using CSharpGuidBenchmarks.Entities;
using CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities.Abstractions;
using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities.Abstractions;
using CSharpGuidBenchmarks.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq;

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
    
    // long non clustered primary key entities 
    public DbSet<GuidV4NonClusteredPkWithLongSeqClusteredEntity> GuidV4NonClusteredPkWithLongSeqClusteredEntities { get; set; }
    public DbSet<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity> GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntities { get; set; }
    public DbSet<GuidV7NonClusteredPkWithLongSeqClusteredEntity> GuidV7NonClusteredPkWithLongSeqClusteredEntities { get; set; }
    public DbSet<GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity> GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntities { get; set; }
    
    // DateTime non clustered primary key entities
    public DbSet<GuidV4NonClusteredPkWithIntSeqClusteredEntity> GuidV4NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }
    public DbSet<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity> GuidV4Bin16NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }
    public DbSet<GuidV7NonClusteredPkWithIntSeqClusteredEntity> GuidV7NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }
    public DbSet<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity> GuidV7Bin16NonClusteredPkWithDateTimeSeqClusteredEntities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        DefineClusteredPkEntitiesModelMapping(modelBuilder);
        DefineIntClusteredPkWithAlternateGuidModelMapping(modelBuilder);
        
        
        modelBuilder.ApplyAlternateKeyMapping();
        modelBuilder.ApplyBinaryGuidMapping();


        // OnClusteredPkEntitiesModelCreating(modelBuilder);
        // OnNonClusteredPkWithIntSeqClusteredEntitiesModelCreating(modelBuilder);
        // OnNonClusteredPkWithLongSeqClusteredEntitiesModelCreating(modelBuilder);
        // OnNonClusteredPkWithDateTimeSeqClusteredEntitiesModelCreating(modelBuilder);
        //
        // var nonClusteredPrimaryKeyEntities = modelBuilder.Model.GetEntityTypes()
        //     .Where(t => t.ClrType.IsAssignableToGenericType(typeof(INonClusteredPrimaryKeyEntity<>)));
        //
        // foreach (var nonClusteredPrimaryKeyEntity in nonClusteredPrimaryKeyEntities)
        // {
        //     modelBuilder.Entity(nonClusteredPrimaryKeyEntity.ClrType)
        //         .HasKey(nameof(INonClusteredPrimaryKeyEntity<bool>.PrimaryKey))
        //         .IsClustered(false);
        // }
        //
        //
        // var clusteredIndexEntities = modelBuilder.Model.GetEntityTypes()
        //     .Where(t => t.ClrType.IsAssignableToGenericType(typeof(IClusteredIndexEntity<>)));
        //
        // foreach (var clusteredIndexEntity in clusteredIndexEntities)
        // {
        //     var entityTypeBuilder = modelBuilder.Entity(clusteredIndexEntity.ClrType);
        //     entityTypeBuilder
        //         .HasAlternateKey(nameof(IClusteredIndexEntity<bool>.AlternateKey))
        //         .IsClustered();
        //
        //     var type = clusteredIndexEntity.ClrType;
        //     var isSequentialClustered = type.IsAssignableToGenericType(
        //                                     typeof(NonClusteredPrimaryKeyWithIntSeqClusteredEntity<>))
        //                                 || type.IsAssignableToGenericType(
        //                                     typeof(NonClusteredPrimaryKeyWithLongSeqClusteredEntity<>));
        //
        //     if (isSequentialClustered)
        //     {
        //         entityTypeBuilder.Property(nameof(IClusteredIndexEntity<bool>.AlternateKey))
        //             .ValueGeneratedOnAdd();
        //     }
        // }
    }



    private static void DefineClusteredPkEntitiesModelMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IntClusteredPkEntity>();
        modelBuilder.Entity<GuidV4ClusteredPkEntity>();
        modelBuilder.Entity<GuidV4Bin16ClusteredPkEntity>();
        modelBuilder.Entity<GuidV7ClusteredPkEntity>();
        modelBuilder.Entity<GuidV7Bin16ClusteredPkEntity>();
    }

    private static void DefineIntClusteredPkWithAlternateGuidModelMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IntClusteredPkWithAlternateGuidV4Entity>();
        modelBuilder.Entity<IntClusteredPkWithAlternateGuidV4Bin16Entity>();
        modelBuilder.Entity<IntClusteredPkWithAlternateGuidV7Entity>();
        modelBuilder.Entity<IntClusteredPkWithAlternateGuidV7Bin16Entity>();
    }
    
    private static void OnNonClusteredPkWithIntSeqClusteredEntitiesModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GuidV4NonClusteredPkWithIntSeqClusteredEntity>();
        modelBuilder.Entity<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity>();
        modelBuilder.Entity<GuidV7NonClusteredPkWithIntSeqClusteredEntity>();
        modelBuilder.Entity<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity>();
    }
    
    private static void OnNonClusteredPkWithLongSeqClusteredEntitiesModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GuidV4NonClusteredPkWithLongSeqClusteredEntity>();
        modelBuilder.Entity<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity>();
        modelBuilder.Entity<GuidV7NonClusteredPkWithLongSeqClusteredEntity>();
        modelBuilder.Entity<GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity>();
    }
    
    private static void OnNonClusteredPkWithDateTimeSeqClusteredEntitiesModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GuidV4NonClusteredPkWithDateTimeClusteredEntity>();
        modelBuilder.Entity<GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity>();
        modelBuilder.Entity<GuidV7NonClusteredPkWithDateTimeClusteredEntity>();
        modelBuilder.Entity<GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity>();
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
            entityBuilder.HasAlternateKey(nameof(IClusteredIndexEntity<bool>.AlternateKey));
        }
    }
}