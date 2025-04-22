using AutoMapper;
using Hackathon.UserService.DTOs;
using Hackathon.UserService.Models;

namespace Hackathon.UserService.Mappings;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<MedicoDto, Medico>();
        CreateMap<Medico, MedicoDto>();

        CreateMap<PacienteDto, Paciente>();
        CreateMap<Paciente, PacienteDto>();
    }
}
