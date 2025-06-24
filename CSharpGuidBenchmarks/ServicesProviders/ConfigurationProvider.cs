using Microsoft.Extensions.Configuration;

namespace CSharpGuidBenchmarks.ServicesProviders;

public class CustomConfigurationProvider
{
    public static IConfigurationRoot Configuration => _configuration.Value;
    private static readonly Lazy<IConfigurationRoot> _configuration = new(GetConfiguration);

    private static IConfigurationRoot GetConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddUserSecrets<Program>()
            .Build();

        return configuration;
    }
} 