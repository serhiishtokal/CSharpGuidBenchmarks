namespace CSharpGuidBenchmarks.Entities;

public interface IClusteredPkEntity<TPk>
{
    TPk PrimaryKey { get; set; }
}