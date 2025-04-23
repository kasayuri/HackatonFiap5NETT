using AutoMapper;
using Hackathon.ScheduleService.Data;
using Hackathon.ScheduleService.DTOs;
using Hackathon.ScheduleService.Models;

namespace Hackathon.ScheduleService.Services;

public class AgendamentoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AgendamentoService(IUnitOfWork uow, IMapper mapper)
    {
        _unitOfWork = uow;
        _mapper = mapper;
    }

    public async Task<List<AgendamentoDto>> GetAgendamentos()
    {
        var schedules = await _unitOfWork.Agendamentos.GetAllAsync();
        return _mapper.Map<List<AgendamentoDto>>(schedules);
    }

    public async Task CreateAgendamento(Agendamento schedule)
    {
        await _unitOfWork.Agendamentos.AddAsync(schedule);
        await _unitOfWork.CommitAsync();
    }

    public async Task<Agendamento?> EditarAgendamento(Guid id, DateTime novaData)
    {
        var horario = await _unitOfWork.Agendamentos.GetByIdAsync(id);

        if (horario == null)
            return null;

        horario.DataHora = novaData;

        await _unitOfWork.Agendamentos.UpdateAsync(horario);
        await _unitOfWork.CommitAsync();

        return horario;
    }

    public async Task DeleteAgendamento(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("O ID fornecido não é válido.", nameof(id));

        var horario = await _unitOfWork.Agendamentos.GetByIdAsync(id);
        if (horario == null)
            throw new KeyNotFoundException("O horário não foi encontrado");

        await _unitOfWork.Agendamentos.DeleteAsync(horario);
        await _unitOfWork.CommitAsync();
    }
}
