using CSharpGuidBenchmarks.Domain.Abstractions;
using CSharpGuidBenchmarks.Domain.Attributes;
using CSharpGuidBenchmarks.Domain.Interfaces;
using CSharpGuidBenchmarks.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Infrastructure.Postgres.DbContexts;

public static class ModelBuilderExtensions
{
    public static void ApplyBinaryGuidMapping(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var guidProperties = entityType.GetProperties()
                .Where(p => p.ClrType == typeof(Guid) && 
                            p.PropertyInfo?.IsDefined(typeof(BinaryGuidAttribute), inherit: true) == true);
            
            foreach (var prop in guidProperties)
            {
                prop.SetColumnType("bytea");
                prop.SetValueConverter(BinaryGuidConverter.Instance);
                prop.SetMaxLength(16);

                entityType.AddCheckConstraint(
                    $"CK_{entityType.GetTableName()}_{prop.Name}_Length",
                    $"octet_length(\"{prop.Name}\") = 16");
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
                property.HasDefaultValueSql("NOW() AT TIME ZONE 'UTC'");
            }
        }
    }
}