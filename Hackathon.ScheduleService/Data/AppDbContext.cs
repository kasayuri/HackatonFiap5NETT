using Hackathon.ScheduleService.Models;
using Microsoft.EntityFrameworkCore;
namespace Hackathon.ScheduleService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Agendamento> Agendamentos { get; set; }
}

