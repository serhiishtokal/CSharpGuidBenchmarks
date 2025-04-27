// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using CSharpGuidBenchmarks.Benchmarks;
using CSharpGuidBenchmarks.Infrastructure;

Console.WriteLine("Hello, World!");
await DbStaticServices.ResetDbAsync();
// var summary = BenchmarkRunner.Run<SqlWriteEntityBenchmark>();