using Microsoft.EntityFrameworkCore;
using Hackathon.AuthService.Models;
using System.Collections.Generic;

namespace Hackathon.AuthService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}


