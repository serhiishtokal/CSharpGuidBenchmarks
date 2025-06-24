using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CSharpGuidBenchmarks.Infrastructure.Extensions;

public static class DbContextExtensions
{
    public static async Task<Dictionary<string, int>> GetEntityCountsAsync(this DbContext context)
    {
        var dbSetProperties = context.GetType().GetProperties()
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
        var counts = new Dictionary<string, int>();
        foreach (var property in dbSetProperties)
        {
            var entityType = property.PropertyType.GetGenericArguments()[0];
            var entityName = entityType.Name;
            var dbSet = property.GetValue(context) as IQueryable<object>;
            var count = -1;
            if (dbSet != null)
            {
                count = await dbSet.CountAsync();
            }

            counts[entityName] = count;
        }

        return counts;
    }

    public static async Task<Dictionary<string, int?>> GetEntityCountsParallelAsync<TContext>(
        this IDbContextFactory<TContext> dbContextFactory)
        where TContext : DbContext
    {
        var countTasks = typeof(TContext)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .Select(async p =>
            {
                var count = await GetCountForDbContextPropertyAsync(p);
                return new KeyValuePair<string, int?>(p.Name, count);
            });


        var results = await Task.WhenAll(countTasks);
        return results.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        async Task<int?> GetCountForDbContextPropertyAsync(PropertyInfo property)
        {
            int? count = null;
            try
            {
                await using var context = await dbContextFactory.CreateDbContextAsync();
                if (property.GetValue(context) is not IQueryable<object> dbSetInstance)
                {
                    return null;
                }

                count = await dbSetInstance.CountAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return count;
        }
    }
}