using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Hackathon.AuthService.Services;

public class TokenService
{
    public static string GenerateToken(string tipo, string doc)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-super-secreta"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: new[]
            {
                    new Claim("tipo", tipo),
                    new Claim("doc", doc)
            },
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
