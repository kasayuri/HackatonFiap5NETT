using Microsoft.EntityFrameworkCore;
using Hackathon.ScheduleService.Data;
using Prometheus;
using Hackathon.ScheduleService.Repositories;
using Hackathon.ScheduleService.Configuration;
using Hackathon.ScheduleService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseHttpMetrics(); // Prometheus  

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hackathon Schedule Service API v1");
    c.RoutePrefix = ""; // Mostra no root (localhost:500x/)
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapMetrics();     // Prometheus  

app.Services.ApplyDatabaseMigrations(maxRetries: 3, delay: 5000);

app.Run();
