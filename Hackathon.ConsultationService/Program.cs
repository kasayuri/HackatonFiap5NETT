using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Prometheus;
using Hackathon.ConsultationService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
   opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(opt =>
   {
       opt.TokenValidationParameters = new()
       {
           ValidateIssuer = false,
           ValidateAudience = false,
           ValidateLifetime = true,
           IssuerSigningKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes("minha-chave-super-secreta")
           )
       };
   });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var maxRetries = 10;
    var delay = 5000;

    for (int attempt = 1; attempt <= maxRetries; attempt++)
    {
        try
        {
            Console.WriteLine($"Tentativa {attempt} de conectar ao banco...");
            db.Database.Migrate();
            Console.WriteLine("Migração concluída!");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}");

            if (attempt == maxRetries)
            {
                Console.WriteLine("Número máximo de tentativas atingido.");
                throw;
            }

            Thread.Sleep(delay);
        }
    }
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpMetrics(); // Prometheus  
app.MapMetrics();     // Prometheus  

app.MapControllers();
app.Run();
