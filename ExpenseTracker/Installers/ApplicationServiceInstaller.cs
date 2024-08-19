using Application.AppDBContext;
using Application.MappingProfiles;
using ExpenseTracker.Installers.Base;
using FluentValidation;

namespace ExpenseTracker.Installers
{
    public sealed class ApplicationServiceInstaller : IServiceInstaller
    {
        public void InstallService(IHostBuilder host, IServiceCollection services, IConfiguration configuration)
        {
            //MediatR
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<IAppDBContext>());

            //Automapper
            services.AddAutoMapper(typeof(ApplicationMappingProfile));

            //Fluent Validator
            services.AddValidatorsFromAssemblyContaining<IAppDBContext>(ServiceLifetime.Singleton);
        }
    }
}
