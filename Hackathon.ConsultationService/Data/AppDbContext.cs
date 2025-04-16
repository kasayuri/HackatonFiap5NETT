using Hackathon.ConsultationService.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ConsultationService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Consultation> Consultations { get; set; }
}
