namespace Hackathon.ConsultationService.DTOs;

public class CreateConsultationDto
{
    public string MedicoCRM { get; set; }
    public string PacienteDocumento { get; set; }
    public DateTime DataHora { get; set; }
}