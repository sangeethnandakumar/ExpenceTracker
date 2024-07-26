using Application.BL.Reports.Get;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Extensions;
using Presentation.Models;
using System.Data;

namespace Presentation.Modules
{
    public sealed class ReportsModule : CarterModule
    {
        public ReportsModule() : base("reports")
        {
            WithTags("Reports");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //POST
            app.MapGet("/", async ([FromQuery] string? start, [FromQuery] string? end, IMediator mediator) =>
            {
                var result = await mediator.Send(new GenerateReportQuery
                {
                    Start = start,
                    End = end
                });

                return result.Match(
                        s => Results.Ok(s),
                        f => f switch
                        {
                            ValidationException validationException => Results.BadRequest(validationException.ToStandardResponse()),
                            DataException anotherException => Results.NotFound(anotherException.ToStandardResponse()),
                            _ => Results.UnprocessableEntity(f.Message)
                        });
            });
        }
    }
}
