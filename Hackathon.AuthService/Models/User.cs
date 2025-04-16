namespace Hackathon.AuthService.Models;

public class User
{
    public Guid Id { get; set; }
    public string Tipo { get; set; } // "medico" ou "paciente"
    public string Documento { get; set; } // CRM ou CPF/email
    public string PasswordHash { get; set; }
}
