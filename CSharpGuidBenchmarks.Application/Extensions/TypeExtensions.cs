namespace CSharpGuidBenchmarks.Extensions;

public static class TypeExtensions
{
    /// <summary>
    /// Returns true if <paramref name="givenType"/> is, inherits from, or implements
    /// the open‐generic <paramref name="genericTypeDefinition"/> (e.g. IFoo&lt;&gt;).
    /// </summary>
    public static bool IsAssignableToGenericType(this Type givenType, Type genericTypeDefinition)
    {
        if (givenType.IsGenericType
            && givenType.GetGenericTypeDefinition() == genericTypeDefinition)
            return true;

        var containsInterface = givenType.GetInterfaces()
            .Where(x => x.IsGenericType)
            .Where(x => x.GetGenericTypeDefinition() == genericTypeDefinition)
            .Any();
        
        if (containsInterface)
            return true;
        
        return givenType.BaseType != null
               && givenType.BaseType.IsAssignableToGenericType(genericTypeDefinition);
    }
    
    /// <summary>
    /// Returns the friendly short name of a type, including generic arguments (e.g. List<String>).
    /// </summary>
    public static string GetShortName(this Type type)
    {
        if (type.IsGenericType)
        {
            // Get the base name up to the backtick (e.g. “Dictionary`2” → “Dictionary”)
            var baseName = type.Name;
            var tickIndex = baseName.IndexOf('`');
            if (tickIndex > 0)
                baseName = baseName.Substring(0, tickIndex);

            // Recursively get short names of generic arguments
            var args = type.GetGenericArguments()
                .Select(t => t.GetShortName())
                .ToArray();

            return $"{baseName}<{string.Join(", ", args)}>";
        }
        else if (type.IsArray)
        {
            // Handle array types (e.g. Int32[] → Int32[])
            return $"{type.GetElementType()!.GetShortName()}[]";
        }
        else
        {
            return type.Name;
        }
    }
}