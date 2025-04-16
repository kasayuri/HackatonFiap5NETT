
using Microsoft.AspNetCore.Mvc;
using Hackathon.AuthService.Data;
using Hackathon.AuthService.Models;
using Hackathon.AuthService.Services;
using System.Security.Cryptography;
using System.Text;

namespace Hackathon.AuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context) => _context = context;

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        user.PasswordHash = Hash(user.PasswordHash);
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok("Usuário registrado");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User login)
    {
        var user = _context.Users.FirstOrDefault(u => u.Documento == login.Documento);
        if (user == null || user.PasswordHash != Hash(login.PasswordHash))
            return Unauthorized("Credenciais inválidas");

        var token = TokenService.GenerateToken(user.Tipo, user.Documento);
        return Ok(new { token });
    }

    private string Hash(string senha)
    {
        using var sha = SHA256.Create();
        return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(senha)));
    }
}