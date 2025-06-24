// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using GuidV7V4CreationBenchmarks;

var summary = BenchmarkRunner.Run<GuidV7V4CreationBenchmark>();
Console.ReadLine();