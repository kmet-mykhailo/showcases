using IdempotentApiDemo.AppContracts.Models.Commands;
using IdempotentApiDemo.AppContracts.Repositories;
using IdempotentApiDemo.AppContracts.Services;
using IdempotentApiDemo.Repositories;
using IdempotentApiDemo.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped(typeof(IIdempotentKeyRepository<>), typeof(IdempotentKeyRepository<>));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddMemoryCache();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapPost("orders", async (CreateOrderCommand command, IOrderService orderService, CancellationToken cancellationToken) =>
    await orderService.CreateOrderAsync(command, cancellationToken));

app.Run();