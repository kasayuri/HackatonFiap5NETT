using System.ComponentModel.DataAnnotations;

namespace Hackathon.UserService.DTOs;

public class PacienteDto
{
    public string Nome { get; set; }
    
    public string CPF { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}