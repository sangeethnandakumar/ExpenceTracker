
using Application.Entries.Commands.CreateEntry;
using Domain.Abstractions;
using Infrastructure.Repositories;

namespace ExpenceTracker.Installers
{
    public sealed class ApplicationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            //MediatR
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateEntryCommand>());

            //Dependencies
            services.AddSingleton<IEntryRepository, EntryRepository>();
        }
    }
}
