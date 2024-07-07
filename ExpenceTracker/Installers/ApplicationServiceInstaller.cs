using Application.AppDBContext;
using Application.Entries.Commands.Create;
using Application.MappingProfiles;
using ExpenceTracker.Installers.Base;
using FluentValidation;

namespace ExpenceTracker.Installers
{
    public sealed class ApplicationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IHostBuilder host, IServiceCollection services, IConfiguration configuration)
        {
            //MediatR
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateEntryCommand>());

            //Automapper
            services.AddAutoMapper(typeof(MappingProfile));

            //Fluent Validator
            services.AddValidatorsFromAssemblyContaining<IAppDBContext>(ServiceLifetime.Singleton);
        }
    }
}
