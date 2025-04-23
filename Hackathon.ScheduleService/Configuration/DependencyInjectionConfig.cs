using Hackathon.ScheduleService.Data;
using Hackathon.ScheduleService.Repositories;
using Hackathon.ScheduleService.Services;

namespace Hackathon.ScheduleService.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<AgendamentoService>();

        return services;
    }
}
