using Application.Entries.Commands.Create;
using Application.Entries.Queries.Get;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Presentation.Models;

namespace Presentation
{
    public sealed class ConfigModule : CarterModule
    {
        public ConfigModule() : base("config")
        {
            WithTags("Config");
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
        }
    }
}
