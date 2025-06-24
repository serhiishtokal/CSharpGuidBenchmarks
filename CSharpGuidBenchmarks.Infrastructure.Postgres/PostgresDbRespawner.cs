using CSharpGuidBenchmarks.Application.Services.Abstractions;
using CSharpGuidBenchmarks.Infrastructure.Common;
using CSharpGuidBenchmarks.Infrastructure.Postgres.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using Respawn;
using Respawn.Graph;

namespace CSharpGuidBenchmarks.Infrastructure.Postgres;

public interface IPostgresDbRespawner : IDbRespawner;

public class PostgresDbRespawner : IPostgresDbRespawner
{
    private readonly ILogger<PostgresDbRespawner> _logger;
    private readonly IConfiguration _configuration;
    private readonly IDbContextFactory<PostgresDbContext> _dbContextFactory;
    private readonly IOptions<ConnectionStringOptions> _connectionStringOptions;

    public PostgresDbRespawner(ILogger<PostgresDbRespawner> logger, IConfiguration configuration, 
        IDbContextFactory<PostgresDbContext> dbContextFactory, IOptions<ConnectionStringOptions> connectionStringOptions)
    {
        _configuration = configuration;
        _dbContextFactory = dbContextFactory;
        _connectionStringOptions = connectionStringOptions;
        _logger = logger;
    }
    
    public async Task HardRespawnAsync()
    {
        _logger.LogInformation("Respawning PostgreSQL DB...");
        try
        {
            await using var postgresDbContext = await _dbContextFactory.CreateDbContextAsync();
            await postgresDbContext.Database.EnsureDeletedAsync();
            await postgresDbContext.Database.MigrateAsync();
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
            await using var postgresDbContext = await _dbContextFactory.CreateDbContextAsync();
            entityTypes = entityTypesToIgnore
                .Select(t => postgresDbContext.Model.FindEntityType(t))
                .OfType<IEntityType>()
                .ToArray();
        }

        await SoftRespawnAsync(entityTypes);
    }

    public async Task SoftRespawnAsync(params IEntityType[] entityTypesToIgnore)
    {
        _logger.LogInformation("Respawning PostgreSQL DB...");
        var tablesToIgnore = entityTypesToIgnore
            .Select(et =>
            {
                var tableName = et.GetTableName()!;
                var schemaName = et.GetSchema() ?? "public";
                return new Table(schemaName, tableName);
            })
            .ToArray();

        var timeout = _configuration.GetValue<int>("DbRespawnTimeoutSeconds");
        var connectionString = _connectionStringOptions.Value.PostgresDbConnection;
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("DbContext has no configured connection string.");
        }

        var csb = new NpgsqlConnectionStringBuilder(connectionString)
        {
            CommandTimeout = timeout
        };
        connectionString = csb.ConnectionString;
        await using var npgsqlConnection = new NpgsqlConnection(connectionString);
        await npgsqlConnection.OpenAsync();

        try
        {
            var respawner = await Respawner.CreateAsync(
                npgsqlConnection,
                new RespawnerOptions
                {
                    TablesToIgnore = tablesToIgnore,
                    DbAdapter = DbAdapter.Postgres
                });

            await respawner.ResetAsync(npgsqlConnection);
            _logger.LogInformation("Database respawned successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to respawn the database.");
            throw;
        }
    }
}