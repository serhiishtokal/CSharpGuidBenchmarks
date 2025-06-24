using System.ComponentModel.DataAnnotations;

namespace CSharpGuidBenchmarks.Infrastructure.Common;

public record ConnectionStringOptions
{
    [Required]
    public string SqlServerDbConnection { get; init; } = null!;
    
    [Required]
    public string PostgresDbConnection { get; init; } = null!;
}