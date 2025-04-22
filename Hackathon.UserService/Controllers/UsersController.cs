using Microsoft.AspNetCore.Mvc;
using Hackathon.UserService.DTOs;
using Hackathon.UserService.Services;
using Hackathon.UserService.Models;
using Hackathon.UserService.Binders;

namespace Hackathon.UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsersController(UsuarioService service)
    {
        _usuarioService = service;
    }

    [HttpPost("medico")]
    public async Task<IActionResult> CriarMedico([FromBody] MedicoDto dto)
    {
        await _usuarioService.CriarMedicoAsync(dto);
        return Ok("Médico criado com sucesso.");
    }

    /// <summary>
    /// Pode fazer chamadas por especialidade: /api/users/medicos?especialidade=cardiologia
    /// </summary>
    /// <param name="especialidade"></param>
    /// <returns></returns>
    [HttpGet("medicos")]
    public async Task<IActionResult> ListarMedicos([ModelBinder(BinderType = typeof(EnumMemberModelBinder<EspecialidadeEnum>))] EspecialidadeEnum? especialidade)
    {
        var medicos = await _usuarioService.ListarMedicosAsync();

        if (especialidade.HasValue) 
            medicos = medicos.Where(m => m.Especialidade == especialidade.Value).ToList();

        return Ok(medicos);
    }

    [HttpPost("paciente")]
    public async Task<IActionResult> CriarPaciente([FromBody] PacienteDto dto)
    {
        await _usuarioService.CriarPacienteAsync(dto);
        return Ok("Paciente criado com sucesso.");
    }

    [HttpGet("paciente/{cpf}")]
    public async Task<IActionResult> ObterPaciente(string cpf)
    {
        var pacienteDto = await _usuarioService.ObterPacienteAsync(cpf);

        if (pacienteDto == null) return NotFound();
        return Ok(pacienteDto);
    }
}
