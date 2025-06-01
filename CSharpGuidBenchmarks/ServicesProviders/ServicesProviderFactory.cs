using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.IntClusteredPkWithGuidAlternate;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.DateTimeSeqClusteredEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.IntEntities;
using CSharpGuidBenchmarks.Domain.Entities.NonClusteredPrimaryKeyEntities.Guids.SeqClusteredIndexEntities.LongEntities;
using CSharpGuidBenchmarks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CSharpGuidBenchmarks.Services;
using CSharpGuidBenchmarks.Services.Abstractions;

namespace CSharpGuidBenchmarks.ServicesProviders;

public class ServiceProviderFactory
{
    public static ServiceProvider CreateForDbInsertGuidBenchmark(DbInsertGuidBenchmarkServiceConfiguration dbInsertGuidBenchmarkServiceConfiguration)
    {
        var configuration = CustomConfigurationProvider.Configuration;
        
        var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(dbConnectionString))
        {
            throw new InvalidOperationException("Could not find connection string");
        }

        var services = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)
            .AddDbContextFactory<BenchmarkDbContext>(options =>
                options.UseSqlServer(dbConnectionString)
            )
            .AddDbInsertGuidBenchmarkServices()
            //.AddSingleton<IDbInsertGuidBenchmarkServiceFactory, DbInsertGuidBenchmarkServiceFactory>()
            .AddSingleton(dbInsertGuidBenchmarkServiceConfiguration);
        
        var serviceProvider = services.BuildServiceProvider();
        
        return serviceProvider;
    }
}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbInsertGuidBenchmarkServices(this IServiceCollection services)
    {
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4Bin16ClusteredPkEntity>, DbInsertGuidV4Bin16ClusteredPkEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4ClusteredPkEntity>, DbInsertGuidV4ClusteredPkEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7Bin16ClusteredPkEntity>, DbInsertGuidV7Bin16ClusteredPkEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7ClusteredPkEntity>, DbInsertGuidV7ClusteredPkEntityBenchmarkService>();

        services.AddTransient<IDbInsertGuidBenchmarkService<IntClusteredPkEntity>, DbInsertIntClusteredPkEntityBenchmarkService>();

        services.AddTransient<IDbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV4Bin16Entity>, DbInsertIntClusteredPkWithAlternateGuidV4Bin16EntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV4Entity>, DbInsertIntClusteredPkWithAlternateGuidV4EntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV7Bin16Entity>, DbInsertIntClusteredPkWithAlternateGuidV7Bin16EntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<IntClusteredPkWithAlternateGuidV7Entity>, DbInsertIntClusteredPkWithAlternateGuidV7EntityBenchmarkService>();

        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4Bin16NonClusteredPkWithDateTimeClusteredEntity>, DbInsertGuidV4Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4NonClusteredPkWithDateTimeClusteredEntity>, DbInsertGuidV4NonClusteredPkWithDateTimeClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7Bin16NonClusteredPkWithDateTimeClusteredEntity>, DbInsertGuidV7Bin16NonClusteredPkWithDateTimeClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7NonClusteredPkWithDateTimeClusteredEntity>, DbInsertGuidV7NonClusteredPkWithDateTimeClusteredEntityBenchmarkService>();

        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4Bin16NonClusteredPkWithIntSeqClusteredEntity>, DbInsertGuidV4Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4NonClusteredPkWithIntSeqClusteredEntity>, DbInsertGuidV4NonClusteredPkWithIntSeqClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7Bin16NonClusteredPkWithIntSeqClusteredEntity>, DbInsertGuidV7Bin16NonClusteredPkWithIntSeqClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7NonClusteredPkWithIntSeqClusteredEntity>, DbInsertGuidV7NonClusteredPkWithIntSeqClusteredEntityBenchmarkService>();

        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4Bin16NonClusteredPkWithLongSeqClusteredEntity>, DbInsertGuidV4Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV4NonClusteredPkWithLongSeqClusteredEntity>, DbInsertGuidV4NonClusteredPkWithLongSeqClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7Bin16NonClusteredPkWithLongSeqClusteredEntity>, DbInsertGuidV7Bin16NonClusteredPkWithLongSeqClusteredEntityBenchmarkService>();
        services.AddTransient<IDbInsertGuidBenchmarkService<GuidV7NonClusteredPkWithLongSeqClusteredEntity>, DbInsertGuidV7NonClusteredPkWithLongSeqClusteredEntityBenchmarkService>();

        return services;
    }
}