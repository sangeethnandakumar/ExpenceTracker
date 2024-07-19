using Application.BL.Categories;
using Application.BL.Categories.Create;
using Application.BL.Categories.Delete;
using Application.BL.Categories.GetAll;
using Application.BL.Categories.GetById;
using Application.BL.Categories.Update;
using Application.BL.Tracks.GetAll;
using Application.BL.Tracks.GetById;
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
    public sealed class CategoriesModule : CarterModule
    {
        public CategoriesModule() : base("categories")
        {
            WithTags("Categories");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET
            app.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCategoriesQuery());
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
                var result = await mediator.Send(new GetCategoryQuery(id));
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
            app.MapPost("/", async (CreateCategoryRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateCategoryCommand(
                    request.Title,
                    request.Text,
                    request.Sub,
                    request.Icon
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
            app.MapPut("/{id}", async ([FromRoute] string id, UpdateCategoryRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new UpdateCategoryCommand(
                    id,
                    request.Title,
                    request.Text,
                    request.Sub,
                    request.Icon
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
                var result = await mediator.Send(new DeleteCategoryCommand(id));

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
