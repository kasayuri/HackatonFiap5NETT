using Hackathon.UserService.Data;
using Hackathon.UserService.Repositories;
using Hackathon.UserService.Services;

namespace Hackathon.UserService.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<UsuarioService>();

        return services;
    }
}