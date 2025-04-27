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
}