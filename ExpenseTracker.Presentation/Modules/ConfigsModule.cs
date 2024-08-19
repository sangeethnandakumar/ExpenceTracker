using Application.BL.Configs.Create;
using Application.BL.Configs.Delete;
using Application.BL.Configs.GetAll;
using Application.BL.Configs.GetById;
using Application.BL.Configs.Update;
using AutoMapper;
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
    public sealed class ConfigsModule : CarterModule
    {
        public ConfigsModule() : base("configs")
        {
            WithTags("Configs");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET
            app.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetConfigsQuery());
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
                var result = await mediator.Send(new GetConfigQuery(id));
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
            app.MapPost("/", async (CreateConfigRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateConfigCommand(

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
            app.MapPut("/{id}", async ([FromRoute] string id, UpdateConfigRequest request, IMediator mediator, IMapper mapper) =>
            {
                //Map request to cmd
                var updateConfigCommand = mapper.Map<UpdateConfigCommand>(request);
                var result = await mediator.Send(updateConfigCommand);

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
                var result = await mediator.Send(new DeleteConfigCommand(id));

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
