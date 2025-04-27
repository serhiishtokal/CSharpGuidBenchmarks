namespace CSharpGuidBenchmarks.Entities;

public interface IClusteredAkEntity<TAkType> where TAkType : struct
{
    TAkType AlternateKey { get; set; }
}