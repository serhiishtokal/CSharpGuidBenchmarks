using CSharpGuidBenchmarks.Infrastructure.Common;
using CSharpGuidBenchmarks.Infrastructure.Postgres.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CSharpGuidBenchmarks.Infrastructure.Postgres.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgresDb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextFactory<PostgresDbContext>((sp, options) =>
        {
            var csOpts = sp.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>();
            options.UseNpgsql(csOpts.Value.PostgresDbConnection);
        });
        
        serviceCollection.AddSingleton<IPostgresDbRespawner, PostgresDbRespawner>();
        
        return serviceCollection;
    }
}