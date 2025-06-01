namespace CSharpGuidBenchmarks.Services.Abstractions;

public record DbInsertGuidBenchmarkServiceConfiguration(
    int InitialDbRecordsNumberState,
    int SetupActionChunkSize,
    int RecordsPerBulkInsert,
    Type EntityType);