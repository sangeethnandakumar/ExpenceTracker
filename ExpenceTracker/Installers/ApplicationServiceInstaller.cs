﻿
using Application.Entries.Commands.CreateEntry;
using ExpenceTracker.Installers.Base;

namespace ExpenceTracker.Installers
{
    public sealed class ApplicationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            //MediatR
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateEntryCommand>());
        }
    }
}