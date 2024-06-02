using Application.Users.Commands.CreateUser;
using Carter;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Presentation.User
{
    public sealed class UserModule : CarterModule
    {
        public UserModule() : base("user")
        {
            WithTags("User Endpoints");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateUserCommand(
                    "Sangeeth",
                    "Nandakumar",
                    "sangee",
                    DateTime.Now,
                    LoginMethod.PASSWORD,
                    Gender.MALE));

                return result.Match(s => Results.Ok(), f => Results.BadRequest(f.Message));
            })
            .WithSummary("Logs Income/Expence")
            .WithDescription("Adds income or expence from the user");
        }
    }

}
