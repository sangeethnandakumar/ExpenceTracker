using Application.BL.Tracks.Create;
using Application.BL.Tracks.Delete;
using Application.BL.Tracks.GetAll;
using Application.BL.Tracks.GetById;
using Application.BL.Tracks.Update;
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

    public sealed class TracksModule : CarterModule
    {
        public TracksModule() : base("tracks")
        {
            WithTags("Tracks");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET
            app.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetTracksQuery());
                return result.Match(
                    s => Results.Ok(s),
                    f => f switch
                    {
                        ValidationException validationException => Results.BadRequest(validationException.ToStandardResponse()),
                        DataException anotherException => Results.NotFound(anotherException.ToStandardResponse()),
                        _ => Results.UnprocessableEntity(f.Message)
                    });
            });


            //GET
            app.MapGet("/{id}", async ([FromRoute] string id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetTrackQuery(id));
                return result.Match(
                    s => Results.Ok(s),
                    f => f switch
                    {
                        ValidationException validationException => Results.BadRequest(validationException.ToStandardResponse()),
                        DataException anotherException => Results.NotFound(anotherException.ToStandardResponse()),
                        _ => Results.UnprocessableEntity(f.Message)
                    });
            });


            //POST
            app.MapPost("/", async (CreateTrackRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateTrackCommand(
                        request.Date,
                        request.Exp,
                        request.Inc,
                        request.Notes,
                        request.Category
                ));

                return result.Match(
                        s => Results.Ok(s),
                        f => f switch
                        {
                            ValidationException validationException => Results.BadRequest(validationException.ToStandardResponse()),
                            DataException anotherException => Results.NotFound(anotherException.ToStandardResponse()),
                            _ => Results.UnprocessableEntity(f.Message)
                        });
            });

            //PUT
            app.MapPut("/{id}", async ([FromRoute] string id, UpdateTrackRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new UpdateTrackCommand(
                        id,
                        request.Date,
                        request.Exp,
                        request.Inc,
                        request.Notes,
                        request.Category
                ));

                return result.Match(
                        s => Results.Ok(s),
                        f => f switch
                        {
                            ValidationException validationException => Results.BadRequest(validationException.ToStandardResponse()),
                            DataException anotherException => Results.NotFound(anotherException.ToStandardResponse()),
                            _ => Results.UnprocessableEntity(f.Message)
                        });
            });


            //DELETE
            app.MapDelete("/{id}", async ([FromRoute] string id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteTrackCommand(id));

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
