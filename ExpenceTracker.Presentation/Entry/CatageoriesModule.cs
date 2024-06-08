using Application.Catageories.Commands.Create;
using Application.Catageories.Queries.Get;
using Application.Entries.Commands.Create;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Entry.Models;

namespace Presentation.Entry
{
    public sealed class CatageoriesModule : CarterModule
    {
        public CatageoriesModule() : base("catageories")
        {
            WithTags("Catageories");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async ([FromQuery] Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCatageoryByIdQuery(id));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });

            app.MapPost("/", async (CreateCatageoryRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateCatageoryCommand(request.Name, request.Description, request.Icon));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });
        }
    }
}
