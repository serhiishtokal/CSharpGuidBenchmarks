using CSharpGuidBenchmarks.ServicesProviders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Respawn;
using Respawn.Graph;

namespace CSharpGuidBenchmarks.Infrastructure;

public static class DbContextExtensions
{
    public static async Task ResetDbAsync(this DbContext context)
    {
        Console.WriteLine("Resetting database...");

        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();

        Console.WriteLine("Database reset complete.");
    }

    /// <summary>
    ///   Truncate/delete all tables in the database except the ones whose CLR types are passed in.
    ///   This version opens a brand-new SqlConnection, leaving EF Core’s internal DbConnection untouched.
    /// </summary>
    /// <param name="context">An EF Core DbContext (used only to get the connection string and model).</param>
    /// <param name="entityTypesToIgnore">CLR entity types whose tables should not be truncated/deleted.</param>
    public static async Task RespawnDbAsync(
        this DbContext context,
        params Type[] entityTypesToIgnore)
    {
        // 1) Map each CLR type to its table name, then wrap in Respawner.Table
        var tablesToIgnore = entityTypesToIgnore
            .Select(t => context.Model.FindEntityType(t))
            .OfType<IEntityType>()
            .Select(et =>
            {
                var tableName = et.GetTableName()!;
                var schemaName = et.GetSchema();
                return new Table(schemaName, tableName);
            })
            .ToArray();

        // 2) Pull the same connection string the DbContext is using
        var connectionString = context.Database.GetConnectionString();
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("DbContext has no configured connection string.");
        }

        var commandTimeout = CustomConfigurationProvider.Configuration.GetValue<int>("DbCommandTimeout");

        // 3) Open a new SqlConnection (completely independent of EF Core’s internal connection)
        var csb = new SqlConnectionStringBuilder(connectionString);
        csb.CommandTimeout = commandTimeout;
        connectionString = csb.ConnectionString;
        await using var sqlConnection = new SqlConnection(connectionString);
        await sqlConnection.OpenAsync();

        try
        {
            // 4) Create a Respawner instance against this fresh connection
            var respawner = await Respawner.CreateAsync(
                sqlConnection,
                new RespawnerOptions
                {
                    TablesToIgnore = tablesToIgnore
                });

            // 5) Execute the reset (will truncate all tables except those you passed in)
            await respawner.ResetAsync(sqlConnection);
        }
        finally
        {
            // 6) Dispose (CloseAsync + Dispose) when we’re done
            //    The `await using` already ensures the connection is closed and disposed.
        }
    }

    public static async Task<Dictionary<string, int>> GetEntityCountsAsync(this DbContext context)
    {
        var dbSetProperties = context.GetType().GetProperties()
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
        var counts = new Dictionary<string, int>();
        foreach (var property in dbSetProperties)
        {
            var entityType = property.PropertyType.GetGenericArguments()[0];
            var entityName = entityType.Name;
            var dbSet = property.GetValue(context) as IQueryable<object>;
            var count = -1;
            if (dbSet != null)
            {
                count = await dbSet.CountAsync();
            }

            counts[entityName] = count;
        }

        return counts;
    }

    public static async Task<Dictionary<string, int?>> GetEntityCountsParallelAsync<TContext>(
        this IDbContextFactory<TContext> dbContextFactory)
        where TContext : DbContext
    {
        var countTasks = typeof(TContext)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .Select(async p =>
            {
                var count = await GetCountForDbContextPropertyAsync(p);
                return new KeyValuePair<string, int?>(p.Name, count);
            });


        var results = await Task.WhenAll(countTasks);
        return results.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        async Task<int?> GetCountForDbContextPropertyAsync(PropertyInfo property)
        {
            int? count = null;
            try
            {
                await using var context = await dbContextFactory.CreateDbContextAsync();
                if (property.GetValue(context) is not IQueryable<object> dbSetInstance)
                {
                    return null;
                }

                count = await dbSetInstance.CountAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return count;
        }
    }
}