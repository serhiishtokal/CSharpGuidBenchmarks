using BenchmarkDotNet.Attributes;

namespace GuidV7V4CreationBenchmarks;

[MemoryDiagnoser]
[MediumRunJob]
public class GuidV7V4CreationBenchmark
{
    [Benchmark]
    [IterationCount(100)]// Marks a method as a benchmark
    public void CreateGuidV4()
    {
        var guid = Guid.NewGuid();
    }
    
    [Benchmark(Baseline = true)]
    [IterationCount(100)]// Mark one method as the baseline for comparison
    public void CreateGuidV7()
    {
        var guid = Guid.CreateVersion7();
    }
}