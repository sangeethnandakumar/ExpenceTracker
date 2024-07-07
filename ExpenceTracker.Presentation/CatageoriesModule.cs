using Application.Catageories.Commands.Create;
using Application.Catageories.Queries.Get;
using Application.Catageories.Queries.GetCatageoryById;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Models;

namespace Presentation
{

    public sealed class CatageoriesModule : CarterModule
    {
        public CatageoriesModule() : base("catageories")
        {
            WithTags("Catageories");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", async ([FromRoute] Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCatageoryByIdQuery(id));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });

            app.MapGet("/", async ([FromQuery] Guid? accountId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCatageoriesByUserQuery(accountId));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });

            app.MapPost("/", async ([FromBody]CreateCatageoryRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateCatageoryCommand(
                    request.Name,
                    request.Description,
                    request.Icon,
                    request.IsBuiltIn,
                    request.ParentCatageory,
                    request.AccountId
                    ));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });
        }
    }
}
