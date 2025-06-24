using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSharpGuidBenchmarks.Infrastructure.Postgres.DbContexts;

public class BinaryGuidConverter : ValueConverter<Guid, byte[]>
{
    private static readonly Lazy<BinaryGuidConverter> _lazy = new(() => new BinaryGuidConverter());
    
    public BinaryGuidConverter() 
        : base(
            guid => guid.ToByteArray(),
            bytes => new Guid(bytes))
    {
    }
    
    public static BinaryGuidConverter Instance => _lazy.Value;
}