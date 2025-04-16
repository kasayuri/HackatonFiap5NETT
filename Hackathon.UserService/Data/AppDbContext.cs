using Hackathon.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.UserService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
}
