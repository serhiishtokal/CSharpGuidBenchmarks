using CSharpGuidBenchmarks.Domain;
using CSharpGuidBenchmarks.Infrastructure.Postgres;
using CSharpGuidBenchmarks.Infrastructure.Postgres.DbContexts;
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
            DbTypeEnum.PostgreSql => typeof(PostgresDbContext),
            _ => throw new ArgumentOutOfRangeException(nameof(dbTypeEnum), dbTypeEnum, null)
        };
    }
    
    public static Type GetDbRespawnerType(this DbTypeEnum dbTypeEnum)
    {
        return dbTypeEnum switch
        {
            DbTypeEnum.SqlServer => typeof(ISqlServerDbRespawner),
            DbTypeEnum.PostgreSql => typeof(IPostgresDbRespawner),
            _ => throw new ArgumentOutOfRangeException(nameof(dbTypeEnum), dbTypeEnum, null)
        };
    }
}