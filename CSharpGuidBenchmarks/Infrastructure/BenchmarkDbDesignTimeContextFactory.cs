using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CSharpGuidBenchmarks.Infrastructure;

public class BenchmarkDbDesignTimeContextFactory : IDesignTimeDbContextFactory<BenchmarkDbContext>
{
    public BenchmarkDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
            .Build();

        // Get connection string
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Configure DbContextOptions
        var optionsBuilder = new DbContextOptionsBuilder<BenchmarkDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new BenchmarkDbContext(optionsBuilder.Options);
    }
}