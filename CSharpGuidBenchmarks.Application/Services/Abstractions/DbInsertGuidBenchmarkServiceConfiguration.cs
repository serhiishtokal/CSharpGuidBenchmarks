namespace CSharpGuidBenchmarks.Application.Services.Abstractions;

public record DbInsertGuidBenchmarkServiceConfiguration(
    int InitialDbRecordsNumberState,
    int SetupActionChunkSize,
    int RecordsPerBulkInsert);