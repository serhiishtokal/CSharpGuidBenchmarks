namespace CSharpGuidBenchmarks.Benchmarks;

public static class BenchmarkStateHelper
{
    private static readonly string StateFilePath = Path.Combine(Path.GetTempPath(), "benchmark_prev_entity_type.txt");

    public static Type? GetPreviousEntityType()
    {
        if (!File.Exists(StateFilePath))
        {
            return null;
        }
        
        var typeName = File.ReadAllText(StateFilePath);
        if (string.IsNullOrWhiteSpace(typeName))
        {
            return null;
        }
        
        var type = Type.GetType(typeName);
        if (type == null)
        {
            throw new InvalidOperationException($"Could not load type from saved state: {typeName}");
        }
        
        return type;
    }

    public static void SaveCurrentEntityType(Type entityType)
    {
        var typeName = entityType.AssemblyQualifiedName;
        if (string.IsNullOrEmpty(typeName))
        {
            throw new InvalidOperationException($"AssemblyQualifiedName is null or empty for type: {entityType}");
        }
        
        File.WriteAllText(StateFilePath, typeName);
    }
}
