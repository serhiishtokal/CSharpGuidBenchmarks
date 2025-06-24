using CSharpGuidBenchmarks.Application.Others;
using CSharpGuidBenchmarks.Application.Services.Abstractions;
using CSharpGuidBenchmarks.Application.Services.EntityFactories;
using CSharpGuidBenchmarks.Domain;
using CSharpGuidBenchmarks.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CSharpGuidBenchmarks.ServicesProviders;

public class ServiceProviderFactory
{
    public static ServiceProvider CreateForDbInsertGuidBenchmark(DbGuidBenchmarkGlobalSetupConfiguration benchmarkGlobalConfiguration)
    {
        var configuration = CustomConfigurationProvider.Configuration;

        var services = new ServiceCollection()
            .AddDefaultLogging(configuration)
            .AddSingleton<IConfiguration>(configuration)
            .AddSingleton(benchmarkGlobalConfiguration.ToIterationServiceConfiguration())
            .AddSingleton(typeof(IEntityFakerProvider<>), typeof(EntityFakerProvider<>))
            .AddInfrastructure()
            .AddDbRespawners(benchmarkGlobalConfiguration.DbType)
            .AddDbGuidBenchmarkIterationService(benchmarkGlobalConfiguration.DbType, benchmarkGlobalConfiguration.EntityType);
        
        var serviceProvider = services.BuildServiceProvider();
        
        return serviceProvider;
    }
    
    public static IServiceProvider CreateDbServiceProvider()
    {
        var configuration = CustomConfigurationProvider.Configuration;

        var services = new ServiceCollection()
            .AddDefaultLogging(configuration)
            .AddSingleton<IConfiguration>(configuration)
            .AddInfrastructure();
        
        var serviceProvider = services.BuildServiceProvider();
        
        return serviceProvider;
    }
}

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDbGuidBenchmarkIterationService(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IDbGuidInsertBenchmarkIterationService<,>), typeof(DbGuidInsertBenchmarkIterationService<,>));
        return services;
    }

    public static IServiceCollection AddDbGuidBenchmarkIterationService(this IServiceCollection services, DbTypeEnum dbType, Type entityType)
    {
        var implementationType = typeof(DbGuidInsertBenchmarkIterationService<,>).MakeGenericType(entityType, dbType.GetDbContextType());
        services.AddSingleton(typeof(IDbGuidInsertBenchmarkIterationService), implementationType);
        
        return services;
    }
    
    // add default LOGGING 
    public static IServiceCollection AddDefaultLogging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging(builder =>
        {
            builder
                .AddConfiguration(configuration.GetSection("Logging"))
                .AddConsole()
                .AddDebug();
        });
        
        return services;
    }
    
    public static IServiceCollection AddDbRespawners(this IServiceCollection services, DbTypeEnum dbType)
    {
        var dbRespawnerImplementationType = dbType.GetDbRespawnerType();
        var servicesType = typeof(IDbRespawner);
        
        services.AddSingleton(servicesType, (sp) => sp.GetRequiredService(dbRespawnerImplementationType));
        return services;
    }
}