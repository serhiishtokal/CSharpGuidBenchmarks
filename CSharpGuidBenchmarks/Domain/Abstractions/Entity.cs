using System.ComponentModel.DataAnnotations;
using CSharpGuidBenchmarks.Domain.Interfaces;

namespace CSharpGuidBenchmarks.Domain.Abstractions;

public abstract class Entity<T> : IEntity<T> where T : struct
{
    private Entity() { }
    
    protected Entity(T primaryKey, string payload)
    {
        PrimaryKey = primaryKey;
        Payload = payload;
    }
    
    [Key]
    public virtual T PrimaryKey { get; private set; }
    
    [MaxLength(255)]
    public string Payload { get; private set; }
}