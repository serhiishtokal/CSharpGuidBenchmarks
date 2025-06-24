using Microsoft.Extensions.DependencyInjection;

namespace CSharpGuidBenchmarks.Infrastructure.PostgreSql.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgresDb(this IServiceCollection serviceCollection)
    {
        // serviceCollection.AddDbContextFactory<PostgresDbContext>((sp, options) =>
        // {
        //     var csOpts = sp.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>();
        //     options.UseNpgsql(csOpts.Value.SqlServerDbConnection);
        // });
        
        return serviceCollection;
    }
}