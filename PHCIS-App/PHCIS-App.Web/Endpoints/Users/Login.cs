using Application.Users.Login;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Diagnostics.Latency;
using SharedLibrary.Shared;
using Extensions;
using Infrastructure;

namespace Endpoints.Users;


internal sealed class Login : IEndpoint
{
    public sealed record Request(string Email, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/users/login", async (
            Request request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new LoginUserCommand(request.Email, request.Password);

            Result<string> result =
                (Result<string>)await sender.Send(command, cancellationToken);

            return result.Match(
                token => Results.Ok(new { access_token = token }),
                CustomResults.Problem);
        })
        .AllowAnonymous()
        .WithTags(Tags.Users)
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status401Unauthorized);
        //.WithOpenApi();
    }
}

//internal sealed class Login : IEndpoint
//{
//    public sealed record Request(string Email, string Password);

//    public void MapEndpoint(IEndpointRouteBuilder app)
//    {
//        app.MapPost("/users/login", async (Request request, ISender sender, CancellationToken cancellationToken) =>
//        {
//            var command = new LoginUserCommand(request.Email, request.Password);

//            Result<string> result = await sender.Send(command, cancellationToken);

//            return result.Match(Results.Ok, CustomResults.Problem);
//        })
//        .WithTags(Tags.Users);
//    }
//}
