using Application.Entries.Commands.CreateEntry;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            app.MapPost("/", async (EntryRequest entry, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateEntryCommand(entry.Amount, entry.CurrencyCode));
                return result.Match(s => Results.Ok(), f => Results.BadRequest(f.Message));
            });
        }
    }
}
