using Microsoft.AspNetCore.Mvc;
using Hackathon.UserService.DTOs;
using Hackathon.UserService.Models;
using Hackathon.UserService.Data;

namespace Hackathon.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    public UsersController(AppDbContext context) => _context = context;

    [HttpPost("medico")]
    public IActionResult CriarMedico(CreateMedicoDto dto)
    {
        var medico = new Medico
        {
            Nome = dto.Nome,
            CRM = dto.CRM,
            Especialidade = dto.Especialidade
        };

        _context.Medicos.Add(medico);
        _context.SaveChanges();
        return Ok(medico);
    }

    [HttpGet("medicos")]
    public IActionResult ListarMedicos([FromQuery] string? especialidade)
    {
        var query = _context.Medicos.AsQueryable();

        if (!string.IsNullOrEmpty(especialidade))
            query = query.Where(m => m.Especialidade == especialidade);

        return Ok(query.ToList());
    }

    [HttpPost("paciente")]
    public IActionResult CriarPaciente(CreatePacienteDto dto)
    {
        var paciente = new Paciente
        {
            Nome = dto.Nome,
            CPF = dto.CPF,
            Email = dto.Email
        };

        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return Ok(paciente);
    }

    [HttpGet("paciente/{cpf}")]
    public IActionResult ObterPaciente(string cpf)
    {
        var paciente = _context.Pacientes.FirstOrDefault(p => p.CPF == cpf);
        if (paciente == null) return NotFound();
        return Ok(paciente);
    }
}
