using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;
using CSharpGuidBenchmarks.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Infrastructure.SqlServer.DbContexts;

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