using CSharpGuidBenchmarks.ServicesProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSharpGuidBenchmarks.Infrastructure;

public class DbStaticServices
{
    public static async Task ResetDbAsync()
    {
        var configuration = CustomConfigurationProvider.Configuration;
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        var optionsBuilder = new DbContextOptionsBuilder<BenchmarkDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        await using var context = new BenchmarkDbContext(optionsBuilder.Options);
        await context.ResetDbAsync();
    }
}