using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpGuidBenchmarks.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptionsWithValidateDataAnnotationsOnStart<TOptions>(
        this IServiceCollection services, IConfigurationSection configurationSection)
        where TOptions : class
    {
        services.AddOptions<TOptions>()
            .Bind(configurationSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
    
    public static IServiceCollection AddOptionsWithValidateDataAnnotationsOnStart<TOptions>(
        this IServiceCollection services, string configurationSectionName)
        where TOptions : class
    {
        services.AddOptions<TOptions>()
            .BindConfiguration(configurationSectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}