using Application.BL.Reports.Get;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            app.MapPost("/", async (GenerateReportRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new GenerateReportQuery
                {
                    Start = request.Start,
                    End = request.End
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
