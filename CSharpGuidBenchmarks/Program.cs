// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CSharpGuidBenchmarks.Benchmarks;
using CSharpGuidBenchmarks.Infrastructure.Postgres;
using CSharpGuidBenchmarks.Infrastructure.SqlServer;
using CSharpGuidBenchmarks.ServicesProviders;
using Microsoft.Extensions.DependencyInjection;

var manualConfig = ManualConfig.CreateEmpty();
manualConfig.Add(DefaultConfig.Instance);
manualConfig.SummaryStyle = manualConfig.SummaryStyle.WithMaxParameterColumnWidth(60);

{
    var serviceProvider = ServiceProviderFactory.CreateDbServiceProvider();
    {
        var sqlServerDbRespawner = serviceProvider.GetRequiredService<ISqlServerDbRespawner>();
        await sqlServerDbRespawner.HardRespawnAsync();
    }
    {
        var postgresDbRespawner = serviceProvider.GetRequiredService<IPostgresDbRespawner>();
        await postgresDbRespawner.HardRespawnAsync();
    }
}

BenchmarkRunner.Run<DbInsertGuidBenchmark>(manualConfig);
//BenchmarkRunner.Run<DbInsertGuidBenchmark>(new DebugInProcessConfig());


Console.ReadLine();