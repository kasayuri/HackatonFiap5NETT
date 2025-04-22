using Hackathon.UserService.Data;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.UserService.Extensions;

public static class DatabaseMigrationExtensions
{
    public static void ApplyDatabaseMigrations(this IServiceProvider services, int maxRetries = 3, int delay = 5000)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                Console.WriteLine($"Tentativa {attempt} de conectar ao banco...");
                db.Database.Migrate();
                Console.WriteLine("Migration conclu�da!");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}");

                if (attempt == maxRetries)
                {
                    Console.WriteLine("N�mero m�ximo de tentativas atingido.");
                    throw;
                }

                Thread.Sleep(delay);
            }
        }
    }
}