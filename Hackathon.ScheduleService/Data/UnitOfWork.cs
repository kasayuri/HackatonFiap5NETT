using Hackathon.ScheduleService.Repositories;

namespace Hackathon.ScheduleService.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Agendamentos = new AgendamentoRepository(_context);
    }

    public IAgendamentoRepository Agendamentos { get; }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}