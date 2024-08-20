using Application.BL.DeveloperSuggestions.Create;
using Application.BL.DeveloperSuggestions.Delete;
using Application.BL.DeveloperSuggestions.GetAll;
using Application.BL.DeveloperSuggestions.GetById;
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
    public sealed class DeveloperSuggestionsModule : CarterModule
    {
        public DeveloperSuggestionsModule() : base("developer-suggestions")
        {
            WithTags("DeveloperSuggestions");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET
            app.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetDeveloperSuggestionsQuery());
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
                var result = await mediator.Send(new GetDeveloperSuggestionQuery(id));
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
            app.MapPost("/", async (CreateDeveloperSuggestionRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateDeveloperSuggestionCommand(
                    request.UserId,
                    request.AppName,
                    request.Message
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
                var result = await mediator.Send(new DeleteDeveloperSuggestionCommand(id));

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
