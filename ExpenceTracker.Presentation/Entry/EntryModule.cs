using Application.Entries.Commands.CreateEntry;
using Application.Entries.Queries.FetchEntries;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Entry.Models;

namespace Presentation.Entry
{
    public sealed class EntryModule : CarterModule
    {
        public EntryModule() : base("entries")
        {
            WithTags("Entries");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async ([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, IMediator mediator) =>
            {
                var result = await mediator.Send(new FetchEntriesQuery(startDate, endDate));
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
