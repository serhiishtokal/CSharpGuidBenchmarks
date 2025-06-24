using CSharpGuidBenchmarks.Domain;

namespace CSharpGuidBenchmarks.Application.Others;

public record DbGuidBenchmarkGlobalSetupConfiguration(
    DbTypeEnum DbType,
    Type EntityType,
    int InitialDbRecordsNumberState,
    int SetupActionChunkSize,
    int RecordsPerBulkInsert,
    bool CanHardDbRespawn)
{
    public DbGuidBenchmarkIterationServiceConfiguration ToIterationServiceConfiguration()
    {
        return new DbGuidBenchmarkIterationServiceConfiguration(
            InitialDbRecordsNumberState,
            SetupActionChunkSize,
            RecordsPerBulkInsert,
            CanHardDbRespawn);
    }
}

public record DbGuidBenchmarkIterationServiceConfiguration(
    int InitialDbRecordsNumberState,
    int SetupActionChunkSize,
    int RecordsPerBulkInsert,
    bool CanHardDbRespawn);