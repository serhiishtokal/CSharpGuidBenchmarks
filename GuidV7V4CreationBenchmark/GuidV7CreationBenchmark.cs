using BenchmarkDotNet.Attributes;

namespace GuidV7V4CreationBenchmark;

[MemoryDiagnoser]
[MediumRunJob]
public class GuidV7V4CreationBenchmark
{
    [Benchmark] // Marks a method as a benchmark
    public void CreateGuidV4()
    {
        var guid = Guid.NewGuid();
    }
    
    [Benchmark(Baseline = true)] // Mark one method as the baseline for comparison
    public void CreateGuidV7()
    {
        var guid = Guid.CreateVersion7();
    }
}