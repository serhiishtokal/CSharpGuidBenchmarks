using Microsoft.Extensions.DependencyInjection;

namespace CSharpGuidBenchmarks.Services.Abstractions;

public class DbInsertGuidBenchmarkServiceFactory : IDbInsertGuidBenchmarkServiceFactory
{
    private readonly DbInsertGuidBenchmarkServiceConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public DbInsertGuidBenchmarkServiceFactory(DbInsertGuidBenchmarkServiceConfiguration configuration, IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    public IDbInsertGuidBenchmarkService CreateDbInsertGuidBenchmarkService()
    {
        var type = _configuration.EntityType;
        return (IDbInsertGuidBenchmarkService)ActivatorUtilities.GetServiceOrCreateInstance(_serviceProvider, type);
    }
}