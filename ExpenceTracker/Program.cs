using Carter;
using ExpenceTracker.Installers.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
FindAndInstallServices(builder.Services, builder.Configuration, Assembly.GetExecutingAssembly());


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();
app.Run();

static void FindAndInstallServices(IServiceCollection services, IConfiguration configuration, Assembly assembly)
{
    var installers = assembly.GetTypes()
        .Where(t => typeof(IServiceInstaller).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
        .Select(Activator.CreateInstance)
        .Cast<IServiceInstaller>()
        .ToList();

    installers.ForEach(installer => installer.InstallService(services, configuration));
}