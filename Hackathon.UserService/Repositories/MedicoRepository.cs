using Hackathon.UserService.Data;
using Hackathon.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.UserService.Repositories;

public class MedicoRepository : IMedicoRepository
{
    private readonly AppDbContext _context;
    public MedicoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task Adicionar(Medico medico)
    {
        _context.Medicos.Add(medico);
    }

    public async Task<List<Medico>> ListarTodosAsync()
    {
        return await _context.Medicos.ToListAsync();
    }
}
