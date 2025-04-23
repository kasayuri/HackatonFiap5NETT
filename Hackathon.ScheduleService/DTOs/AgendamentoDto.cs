namespace Hackathon.ScheduleService.DTOs;

public class AgendamentoDto
{
    public string MedicoCRM { get; set; }
    public DateTime DataHora { get; set; }
    public bool Disponivel { get; set; }
}
