﻿using Application.BL.Tracks;
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

namespace Presentation.Tracks
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
            app.MapGet("/", async (IMediator mediator, [FromQuery] string id = null) =>
            {
                if (id is not null)
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
                }
                else
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
                }
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
        }
    }
}