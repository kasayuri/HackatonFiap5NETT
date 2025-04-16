namespace Hackathon.ConsultationService.Models;

public class Consultation
{
    public Guid Id { get; set; }
    public string MedicoCRM { get; set; }
    public string PacienteDocumento { get; set; } // CPF ou email
    public DateTime DataHora { get; set; }
    public string Status { get; set; } // "pendente", "aceita", "recusada", "cancelada"
    public string? JustificativaCancelamento { get; set; }
}
