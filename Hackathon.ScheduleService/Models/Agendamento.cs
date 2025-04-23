namespace Hackathon.ScheduleService.Models;

public class Agendamento
{
    public Guid Id { get; set; }
    public string MedicoCRM { get; set; }
    public DateTime DataHora { get; set; }
    public bool Disponivel { get; set; } = true;
}
