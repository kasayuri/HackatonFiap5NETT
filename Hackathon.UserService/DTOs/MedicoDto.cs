using Hackathon.UserService.Models;

namespace Hackathon.UserService.DTOs;

public class MedicoDto
{
    public string Nome { get; set; }
    public string CRM { get; set; }
    public EspecialidadeEnum Especialidade { get; set; }
}