// using System.Diagnostics;
// using BenchmarkDotNet.Attributes;
// using Microsoft.Extensions.Configuration;
// using CSharpGuidBenchmarks.Entities;
// using CSharpGuidBenchmarks.Entities.ClusteredPrimaryKeys;
// using CSharpGuidBenchmarks.Infrastructure;
// using Microsoft.EntityFrameworkCore;
//
// namespace CSharpGuidBenchmarks.Benchmarks;
//
// // Use SimpleJob for DEV TESTING ONLY. Remove for real measurements.
// // [SimpleJob(RuntimeMoniker.Net80, iterationCount: 2, warmupCount: 1)]
// // [SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 5)]
// // [ShortRunJob]
// [MemoryDiagnoser]
// [SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 5)]
// public class SqlWriteEntityBenchmark
// {
//     [Params(10_000, 50_000, 100_000, 500_000, 1_000_000, 5_000_000, 10_000_000)]
//     public int InitialTotalRecordCount;
//
//     private const int RecordsPerWriteOp = 10_000;
//     private const int SetupActionBatchSize = 100_000; // Batch size for setup inserts/deletes
//     private const int InsertBatchSize = 100;
//
//     private static IConfigurationRoot _configuration = null!;
//     private static string _connectionString = null!;
//     private DbContextOptions<BenchmarkDbContext> _dbContextOptions = null!;
//     private IEnumerable<GuidV4PkBin16ClusteredEntity[]> _intTestEntityChunks = null!;
//
//     [GlobalSetup]
//     public async Task GlobalSetup()
//     {
//          _configuration = new ConfigurationBuilder()
//            .AddEnvironmentVariables()
//            .AddUserSecrets<Program>()
//            .Build();
//          
//         _connectionString = _configuration.GetConnectionString("DefaultConnection")
//             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//         Console.WriteLine($"GlobalSetup: Using Connection String");
//         
//         _dbContextOptions = new DbContextOptionsBuilder<BenchmarkDbContext>()
//             .UseSqlServer(_connectionString)
//             .Options;
//         
//         Console.WriteLine("GlobalSetup: Ensuring database exists...");
//         await using (var context = new BenchmarkDbContext(_dbContextOptions))
//         {
//             await context.Database.EnsureCreatedAsync();
//         }
//         
//         Console.WriteLine("GlobalSetup: Database ready.");
//     }
//
//     [IterationSetup(Target = nameof(WriteLatency_SingleInsertBenchmark))]
//     public void IterationSetup()
//     {
//         Console.WriteLine("----------IterationSetup");
//         EnsureExactRecordCountAsync(InitialTotalRecordCount).GetAwaiter().GetResult();
//         _intTestEntityChunks = Enumerable.Range(0, RecordsPerWriteOp)
//             .Select(x => new GuidV4PkBin16ClusteredEntity())
//             .Chunk(InsertBatchSize);
//     }
//
//     [Benchmark(Description = "Write Latency (Insert 10k - One by One)")]
//     public async Task WriteLatency_SingleInsertBenchmark()
//     {
//         foreach (var intTestEntityChunk in _intTestEntityChunks)
//         {
//             await using var context = new BenchmarkDbContext(_dbContextOptions);
//             await context.IntTestEntities.AddRangeAsync(intTestEntityChunk);
//             await context.SaveChangesAsync();
//         }
//     }
//     
//     [IterationCleanup(Target = nameof(WriteLatency_SingleInsertBenchmark))]
//     public void IterationCleanup()
//     {
//         Console.WriteLine("----------IterationCleanup");
//     }
//     
//     [GlobalCleanup]
//     public static void GlobalCleanup()
//     {
//         Console.WriteLine("----------GlobalCleanup");
//     }
//     
//     private async Task EnsureExactRecordCountAsync(int targetCount)
//     {
//         int currentCount;
//         await using (var context = new BenchmarkDbContext(_dbContextOptions))
//         {
//             currentCount = await context.IntTestEntities.AsNoTracking().CountAsync();
//         }
//         Console.WriteLine($"EnsureExactRecordCountAsync: DB has {currentCount} records. Target is {targetCount}.");
//
//         var difference = targetCount - currentCount;
//
//         switch (difference)
//         {
//             case > 0:
//             {
//                 var sw = Stopwatch.StartNew();
//                 await InsertRecordsBatchedAsync(difference); // Use the fast batch insert helper
//                 sw.Stop();
//                 break;
//             }
//             case < 0:
//             {
//                 var recordsToDelete = -difference;
//                 var sw = Stopwatch.StartNew();
//                 await DeleteRecordsBatchedAsync(recordsToDelete); // Use a batch delete helper
//                 sw.Stop();
//                 break;
//             }
//             default:
//                 Console.WriteLine($"EnsureExactRecordCountAsync: DB already has {currentCount} records. No action needed.");
//                 break;
//         }
//     }
//     
//     private async Task InsertRecordsBatchedAsync(int totalRecordsToInsert)
//     {
//         if (totalRecordsToInsert <= 0) return;
//         
//         var chunks= Enumerable.Range(0, totalRecordsToInsert)
//             .Select(x => new IntTestEntity())
//             .Chunk(SetupActionBatchSize);
//         
//         await using var context = new BenchmarkDbContext(_dbContextOptions);
//         context.ChangeTracker.AutoDetectChangesEnabled = false;
//
//         foreach (var chunk in chunks)
//         {
//             await context.IntTestEntities.AddRangeAsync(chunk);
//             await context.SaveChangesAsync();
//             Console.WriteLine("Inserted {0} records", chunk.Length);
//         }
//         
//         context.ChangeTracker.AutoDetectChangesEnabled = true;
//     }
//     
//     private async Task DeleteRecordsBatchedAsync(long totalRecordsToDelete)
//     {
//         if (totalRecordsToDelete <= 0) return;
//         await using var context = new BenchmarkDbContext(_dbContextOptions);
//         for (long i = 0; i < totalRecordsToDelete; i += SetupActionBatchSize)
//         {
//             var batchSize = (int)Math.Min(SetupActionBatchSize, totalRecordsToDelete - i);
//             if (batchSize <= 0) break;
//             
//             var deleted = await context.IntTestEntities
//                 .OrderBy(e => e.CreatedOnUtc)
//                 .Take(batchSize)
//                 .ExecuteDeleteAsync();
//
//             if (deleted == 0) break;
//             
//             Console.WriteLine("Deleted {0} records", deleted);
//         }
//     }
// }