using Application.BL.Images;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Extensions;
using System.Data;

namespace Presentation.Modules
{
    public sealed class ImagesModule : CarterModule
    {
        public ImagesModule() : base("images")
        {
            WithTags("Images");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET
            app.MapGet("/{id}", async ([FromRoute] string id, IMediator mediator) =>
            {
                //Get image as byte[] from DB
                var result = await mediator.Send(new GetImageQuery(id));
                return result.Match<IResult>(
                    s => {
                        var resultStream = new MemoryStream(s);
                        return Results.File(resultStream, "image/png");
                    },
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
