using Hackathon.ScheduleService.Data;
using Hackathon.ScheduleService.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ScheduleService.Repositories;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly AppDbContext _context;

    public AgendamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Agendamento>> GetAllAsync()
    {
        // Use AsNoTracking for better performance when no changes to entities are needed
        return await _context.Agendamentos.AsNoTracking().ToListAsync();
    }

    public async Task<Agendamento?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("O ID fornecido não é válido.", nameof(id));
        }

        var agendamento = await _context.Agendamentos.FindAsync(id);

        return agendamento;
    }

    public async Task AddAsync(Agendamento schedule)
    {
        if (schedule == null)
        {
            throw new ArgumentNullException(nameof(schedule), "O agendamento não pode ser nulo.");
        }

        await _context.Agendamentos.AddAsync(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Agendamento schedule)
    {
        if (schedule == null)
        {
            throw new ArgumentNullException(nameof(schedule), "O agendamento não pode ser nulo.");
        }

        _context.Agendamentos.Remove(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Agendamento schedule)
    {
        var existingSchedule = await _context.Agendamentos.FindAsync(schedule.Id);
        if (existingSchedule == null)
        {
            throw new KeyNotFoundException("Agendamento não encontrado.");
        }

        _context.Entry(existingSchedule).CurrentValues.SetValues(schedule);
        await _context.SaveChangesAsync();
    }
}