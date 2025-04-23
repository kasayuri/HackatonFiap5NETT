using AutoMapper;
using Hackathon.ScheduleService.DTOs;
using Hackathon.ScheduleService.Models;

namespace Hackathon.ScheduleService.Mappings;

public class AgendamentoProfile : Profile
{
    public AgendamentoProfile()
    {
        CreateMap<AgendamentoDto, Agendamento>();
        CreateMap<Agendamento, AgendamentoDto>();
    }
}
