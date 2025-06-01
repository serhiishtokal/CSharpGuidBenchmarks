using CSharpGuidBenchmarks.ServicesProviders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            .Select(et => {
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

        // 3) Open a new SqlConnection (completely independent of EF Core’s internal connection)
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
}

public class DbStaticServices
{
    public static async Task ResetDbAsync()
    {
        var configuration = CustomConfigurationProvider.Configuration;
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        var optionsBuilder = new DbContextOptionsBuilder<BenchmarkDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        await using var context = new BenchmarkDbContext(optionsBuilder.Options);
        await context.ResetDbAsync();
    }
}