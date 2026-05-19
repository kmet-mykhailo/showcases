using Grpc.Server.API.Services;
using GrpcContracts.Protos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
var app = builder.Build();

app.MapGrpcService<GrpcUserService>();
app.MapGet("/", () => "Hello World!");

app.Run();
