using CSharpGuidBenchmarks.Application.Extensions;
using CSharpGuidBenchmarks.Infrastructure.Common;
using CSharpGuidBenchmarks.Infrastructure.PostgreSql.Extensions;
using CSharpGuidBenchmarks.Infrastructure.SqlServer.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpGuidBenchmarks.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOptionsWithValidateDataAnnotationsOnStart<ConnectionStringOptions>("ConnectionStrings");
        serviceCollection.AddSqlServerDb();
        serviceCollection.AddPostgresDb();
        
        return serviceCollection;
    }
}