using Hackathon.ScheduleService.Repositories;

namespace Hackathon.ScheduleService.Data;

public interface IUnitOfWork : IDisposable
{
    IAgendamentoRepository Agendamentos { get; }
    Task CommitAsync();
}