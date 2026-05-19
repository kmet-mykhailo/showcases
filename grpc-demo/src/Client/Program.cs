using GrpcContracts.Protos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcClient<UserService.UserServiceClient>(options =>
{
    options.Address = new Uri("https://localhost:7284");
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
    return handler;
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/user/{id}", async (string id, UserService.UserServiceClient userService, CancellationToken cancellationToken) =>
{
    GetUserInfoReply result = await userService.GetUserInfoAsync(
        new GetUserInfoRequest { Id = id }, cancellationToken: cancellationToken);
    return Results.Ok(result);
});

app.Run();
