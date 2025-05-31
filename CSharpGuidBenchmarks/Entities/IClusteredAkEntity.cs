namespace CSharpGuidBenchmarks.Entities;

public interface IClusteredAkEntity<TPk, TAk> : IEntity<TPk>
    where TPk : struct
    where TAk : struct
{
    TAk AlternateKey { get; }
}