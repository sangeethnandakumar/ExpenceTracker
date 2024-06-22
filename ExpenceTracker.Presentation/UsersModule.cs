using Application.Users.Commands.Create;
using Application.Users.Queries.GetUserByCredential;
using Application.Users.Queries.GetUserById;
using Carter;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Models;

namespace Presentation
{
    public sealed class UsersModule : CarterModule
    {
        public UsersModule() : base("users")
        {
            WithTags("Users");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", async ([FromRoute] Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetUserByIdQuery(id));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });

            app.MapPost("/fetch", async ([FromBody] GetUserRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetUserByCredentialQuery(
                    new Credential(LogInMode.PASSWORD, request.Email, request.Password)
                    ));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });

            app.MapPost("/", async ([FromBody] CreateUserRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateUserCommand(
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    request.LogInMode,
                    request.DateOfBirth,
                    request.Avatar,
                    request.Gender,
                    request.Country,
                    request.Password
                ));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });
        }
    }
}
