using Hackathon.UserService.Repositories;

namespace Hackathon.UserService.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IMedicoRepository Medicos { get; }
    public IPacienteRepository Pacientes { get; }

    public UnitOfWork(AppDbContext context, IMedicoRepository medicoRepo, IPacienteRepository pacienteRepo)
    {
        _context = context;
        Medicos = medicoRepo;
        Pacientes = pacienteRepo;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
