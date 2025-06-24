using CSharpGuidBenchmarks.Infrastructure.Common;
using CSharpGuidBenchmarks.Infrastructure.SqlServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CSharpGuidBenchmarks.Infrastructure.SqlServer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlServerDb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextFactory<SqlServerDbContext>((sp, options) =>
        {
            var csOpts = sp.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>();
            options.UseSqlServer(csOpts.Value.SqlServerDbConnection);
        });
        
        serviceCollection.AddSingleton<ISqlServerDbRespawner, SqlServerDbRespawner>();
        
        return serviceCollection;
    }
}