using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

using GerenciadorDeUsuarios.Application.Interfaces;
using GerenciadorDeUsuarios.Domain.Entities;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace GerenciadorDeUsuarios.Infrastructure.Security;

public class JwtTokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GerarToken(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email,usuario.Email),
        };

        var chaveSecreta = _configuration["JwtSettings:SecretKey"] ;
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta
            ?? string.Empty));

        var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = credenciais
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);

    }
}
