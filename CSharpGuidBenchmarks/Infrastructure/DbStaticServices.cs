using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSharpGuidBenchmarks.Infrastructure;

public class DbStaticServices
{
    public static async Task ResetDbAsync()
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddUserSecrets<Program>()
            .Build();
         
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        Console.WriteLine($"GlobalSetup: Using Connection String");
        
        var dbContextOptions = new DbContextOptionsBuilder<BenchmarkDbContext>()
            .UseSqlServer(connectionString)
            .Options;
        
        Console.WriteLine("GlobalSetup: Resetting database...");
        await using (var context = new BenchmarkDbContext(dbContextOptions))
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.MigrateAsync();
        }
        
        Console.WriteLine("GlobalSetup: Database ready.");
    }
}