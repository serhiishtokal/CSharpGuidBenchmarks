using CSharpGuidBenchmarks.Application.Services.Abstractions;
using CSharpGuidBenchmarks.Infrastructure.Common;
using CSharpGuidBenchmarks.Infrastructure.SqlServer.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Respawn;
using Respawn.Graph;

namespace CSharpGuidBenchmarks.Infrastructure.SqlServer;

public interface ISqlServerDbRespawner : IDbRespawner;
public class SqlServerDbRespawner : ISqlServerDbRespawner
{
    private readonly ILogger<SqlServerDbRespawner> _logger;
    private readonly IConfiguration _configuration;
    private readonly IDbContextFactory<SqlServerDbContext> _dbContextFactory;
    private readonly IOptions<ConnectionStringOptions> _connectionStringOptions;

    public SqlServerDbRespawner(ILogger<SqlServerDbRespawner> logger, IConfiguration configuration, IDbContextFactory<SqlServerDbContext> dbContextFactory, IOptions<ConnectionStringOptions> connectionStringOptions)
    {
        _configuration = configuration;
        _dbContextFactory = dbContextFactory;
        _connectionStringOptions = connectionStringOptions;
        _logger = logger;
    }
    
    public async Task HardRespawnAsync()
    {
        _logger.LogInformation("Respawning SqlServer DB...");
        try
        {
            // 1) Create a new DbContext instance
            await using var sqlServerDbContext = await _dbContextFactory.CreateDbContextAsync();
            await sqlServerDbContext.Database.EnsureDeletedAsync();
            await sqlServerDbContext.Database.MigrateAsync();
            _logger.LogInformation("Database respawned successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to respawn the database.");
            throw;
        }
    }
    
    public async Task SoftRespawnAsync(params Type[] entityTypesToIgnore)
    {
        IEntityType[] entityTypes; 
        {
            await using var sqlServerDbContext = await _dbContextFactory.CreateDbContextAsync();
            entityTypes = entityTypesToIgnore
                .Select(t => sqlServerDbContext.Model.FindEntityType(t))
                .OfType<IEntityType>()
                .ToArray();
        }

        await SoftRespawnAsync(entityTypes);
    }

    public async Task SoftRespawnAsync(params IEntityType[] entityTypesToIgnore)
    {
        _logger.LogInformation("Respawning SqlServer DB...");
        var tablesToIgnore = entityTypesToIgnore
            // .Select(t => context.Model.FindEntityType(t))
            // .OfType<IEntityType>()
            .Select(et =>
            {
                var tableName = et.GetTableName()!;
                var schemaName = et.GetSchema();
                return new Table(schemaName, tableName);
            })
            .ToArray();

        var timeout = _configuration.GetValue<int>("DbRespawnTimeoutSeconds");
        var connectionString = _connectionStringOptions.Value.SqlServerDbConnection;
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("DbContext has no configured connection string.");
        }

        // 3) Open a new SqlConnection (completely independent of EF Core’s internal connection)
        var csb = new SqlConnectionStringBuilder(connectionString)
        {
            CommandTimeout = timeout
        };
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
            _logger.LogInformation("Database respawned successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to respawn the database.");
            throw;
        }
        finally
        {
            // 6) Dispose (CloseAsync + Dispose) when we’re done
            //    The `await using` already ensures the connection is closed and disposed.
        }
    }
}