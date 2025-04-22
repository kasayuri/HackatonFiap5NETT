using AutoMapper;
using Hackathon.UserService.Data;
using Hackathon.UserService.DTOs;
using Hackathon.UserService.Models;

namespace Hackathon.UserService.Services;

public class UsuarioService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UsuarioService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task CriarMedicoAsync(MedicoDto medicoDto)
    {
        var medico = _mapper.Map<Medico>(medicoDto);
        _uow.Medicos.Adicionar(medico);
        await _uow.CommitAsync();
    }

    public async Task<List<MedicoDto>> ListarMedicosAsync()
    {
        var medicos = await _uow.Medicos.ListarTodosAsync();

        return _mapper.Map<List<MedicoDto>>(medicos);
    }

    public async Task CriarPacienteAsync(PacienteDto pacienteDto)
    {
        var paciente = _mapper.Map<Paciente>(pacienteDto);
        _uow.Pacientes.Adicionar(paciente);
        await _uow.CommitAsync();
    }

    public async Task<PacienteDto?> ObterPacienteAsync(string cpf)
    {
        var paciente = await _uow.Pacientes.ObterPorCpfAsync(cpf);
        if (paciente == null) return null;
        return _mapper.Map<PacienteDto>(paciente);
    }
}
