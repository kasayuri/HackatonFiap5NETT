using Hackathon.ScheduleService.Models;

namespace Hackathon.ScheduleService.Repositories;

public interface IAgendamentoRepository
{
    Task<IEnumerable<Agendamento>> GetAllAsync();
    Task<Agendamento?> GetByIdAsync(Guid id);
    Task AddAsync(Agendamento schedule);
    Task DeleteAsync(Agendamento schedule);
    Task UpdateAsync(Agendamento schedule);
}