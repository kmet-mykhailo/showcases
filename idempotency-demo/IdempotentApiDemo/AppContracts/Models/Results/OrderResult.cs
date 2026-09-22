namespace IdempotentApiDemo.AppContracts.Models.Results;

public sealed record OrderResult(Guid Key, string? Name);