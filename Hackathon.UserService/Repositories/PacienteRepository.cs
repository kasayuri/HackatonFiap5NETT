using Hackathon.UserService.Data;
using Hackathon.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.UserService.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly AppDbContext _context;

    public PacienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
    }

    public async Task<Paciente> ObterPorCpfAsync(string cpf)
    {
        return await _context.Pacientes.FirstOrDefaultAsync(p => p.CPF == cpf);
    }

    public async Task<List<Paciente>> ListarTodosAsync()
    {
        return await _context.Pacientes.ToListAsync();
    }
}
