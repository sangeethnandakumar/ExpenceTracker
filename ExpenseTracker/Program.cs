using Carter;
using ExpenseTracker.Installers.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Install all dependencies
DiscoverAndInstallDependencies(builder.Host, builder.Services, builder.Configuration, Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapCarter();
app.Run();

static void DiscoverAndInstallDependencies(IHostBuilder host, IServiceCollection services, IConfiguration configuration, Assembly assembly)
{
    var installers = assembly.GetTypes()
        .Where(t => typeof(IServiceInstaller).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
        .Select(Activator.CreateInstance)
        .Cast<IServiceInstaller>()
        .ToList();

    installers.ForEach(installer => installer.InstallService(host, services, configuration));
}