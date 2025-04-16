namespace Hackathon.ScheduleService.Models;

public class Schedule
{
    public int Id { get; set; }
    public string MedicoCRM { get; set; }
    public DateTime DataHora { get; set; }
    public bool Disponivel { get; set; } = true;
}
