// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<GuidV7V4CreationBenchmark.GuidV7V4CreationBenchmark>();