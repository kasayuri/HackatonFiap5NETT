using Microsoft.EntityFrameworkCore;
using Hackathon.ScheduleService.Data;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); //Aplica todas as migra��es existentes automaticamente
    // ou: db.Database.EnsureCreated(); //Cria o banco e tabelas se ainda n�o existir, sem hist�rico de migra��es
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpMetrics(); // Prometheus
app.MapMetrics();
app.MapControllers();

app.Run();
