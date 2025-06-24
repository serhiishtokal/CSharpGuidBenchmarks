using CSharpGuidBenchmarks.Domain;
using CSharpGuidBenchmarks.Infrastructure.SqlServer;
using CSharpGuidBenchmarks.Infrastructure.SqlServer.DbContexts;

namespace CSharpGuidBenchmarks.Infrastructure.Extensions;

public static class DbTypeEnumExtensions
{
    public static Type GetDbContextType(this DbTypeEnum dbTypeEnum)
    {
        return dbTypeEnum switch
        {
            DbTypeEnum.SqlServer => typeof(SqlServerDbContext),
            //DbTypeEnum.PostgreSql => typeof(PostgreSqlDbContext),
            _ => throw new ArgumentOutOfRangeException(nameof(dbTypeEnum), dbTypeEnum, null)
        };
    }
    
    public static Type GetDbRespawnerType(this DbTypeEnum dbTypeEnum)
    {
        return dbTypeEnum switch
        {
            DbTypeEnum.SqlServer => typeof(ISqlServerDbRespawner),
            //DbTypeEnum.PostgreSql => typeof(IPostgreSqlDbRespawner),
            _ => throw new ArgumentOutOfRangeException(nameof(dbTypeEnum), dbTypeEnum, null)
        };
    }
}