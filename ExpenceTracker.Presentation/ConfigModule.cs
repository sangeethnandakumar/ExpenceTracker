using Application.Entries.Commands.Create;
using Application.Entries.Queries.Get;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Models;

namespace Presentation
{
    public sealed class ConfigModule : CarterModule
    {
        public ConfigModule() : base("config")
        {
            WithTags("Config");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async ([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetEntriesQuery(startDate, endDate));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });

            app.MapPost("/", async (CreateEntryRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateEntryCommand(request.Amount, request.CurrencyCode));
                return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
            });
        }
    }
}
