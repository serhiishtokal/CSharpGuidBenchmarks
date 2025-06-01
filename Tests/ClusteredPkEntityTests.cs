using CSharpGuidBenchmarks.Domain.Entities.ClusteredPrimaryKeyEntities.GuidPkEntities;
using CSharpGuidBenchmarks.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class ClusteredPkEntityTests
{
    [Fact]
    public async Task Test1()
    {
        const string customPayload = "custompayloadstring";
        await DbStaticServices.ResetDbAsync();
        var dbContextFactory = new BenchmarkDbDesignTimeContextFactory();
        {
            await using var context = dbContextFactory.CreateDbContext([]);
            var guidV7Bin16ClusteredPkEntity = GuidV7Bin16ClusteredPkEntity.Create(customPayload);
            context.Add(guidV7Bin16ClusteredPkEntity);
            await context.SaveChangesAsync();
        }

        {
            await using var context = dbContextFactory.CreateDbContext([]);
                    
            var entity = await context.Set<GuidV7Bin16ClusteredPkEntity>()
                .FirstOrDefaultAsync();
        
            Assert.NotNull(entity);
            Assert.Equal(customPayload, entity.Payload);
        }
    }
}