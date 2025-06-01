// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CSharpGuidBenchmarks.Benchmarks;
using CSharpGuidBenchmarks.Infrastructure;

var manualConfig = ManualConfig.CreateEmpty();
manualConfig.Add(DefaultConfig.Instance);
manualConfig.SummaryStyle = manualConfig.SummaryStyle.WithMaxParameterColumnWidth(60);

await DbStaticServices.ResetDbAsync();

BenchmarkRunner.Run<DbInsertGuidBenchmark>(manualConfig);