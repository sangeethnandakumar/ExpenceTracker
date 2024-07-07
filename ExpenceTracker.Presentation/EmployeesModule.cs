using Application.Employees.Commands;
using Application.Employees.Queries;
using Carter;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Extensions;
using Presentation.Models;

namespace Presentation
{
    public sealed class EmployeesModule : CarterModule
    {
        public EmployeesModule() : base("employees")
        {
            WithTags("Employees");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            //GET
            app.MapGet("/", async ([FromQuery] string id, IMediator mediator) =>
            {
                if (id is not null)
                {
                    var result = await mediator.Send(new GetEmployeeQuery(id));
                    return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
                }
                else
                {
                    var result = await mediator.Send(new GetEmployeesQuery());
                    return result.Match(s => Results.Ok(s), f => Results.BadRequest(f.Message));
                }
            });

            //POST
            app.MapPost("/", async (CreateEmployeeRequest request, IMediator mediator) =>
            {
                var result = await mediator.Send(new CreateEmployeeCommand(
                        request.Name,
                        request.IsDeveloper,
                        request.Age,
                        request.Dob
                ));

                return result.Match(
                    s => Results.Ok(s),
                    f => f is ValidationException validationException
                         ? Results.BadRequest(validationException.ToStandardResponse())
                         : Results.BadRequest(f.Message)
                );
            });
        }
    }
}
