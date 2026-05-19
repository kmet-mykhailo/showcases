using Grpc.Core;

using GrpcContracts.Protos;

namespace Grpc.Server.API.Services;

public class GrpcUserService : UserService.UserServiceBase
{
    public override async Task<GetUserInfoReply> GetUserInfo(GetUserInfoRequest request, ServerCallContext context)
    {
        await Task.Delay(200);
        return new GetUserInfoReply { Name = "John Doe" , Id = request.Id };
    }
}