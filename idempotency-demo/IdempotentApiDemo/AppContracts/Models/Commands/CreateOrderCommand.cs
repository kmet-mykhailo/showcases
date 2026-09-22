namespace IdempotentApiDemo.AppContracts.Models.Commands;

public record CreateOrderCommand(
    string IdempotencyKey, 
    string Details,
    string CommandName = nameof(CreateOrderCommand) 
    ) : IIdempotentCommand;
