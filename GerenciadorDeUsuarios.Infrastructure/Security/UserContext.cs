using GerenciadorDeUsuarios.Application.DTO;
using GerenciadorDeUsuarios.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace GerenciadorDeUsuarios.Infrastructure.Security;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }



    UsuarioAutenticado IUserContext.ObterUsuarioAutenticado()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var claimId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if(Guid.TryParse(claimId, out var userId))
        {
            return new UsuarioAutenticado
            {
                Id = userId,
                Nome = user?.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty,
                Email = user?.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty
            };
        }

        throw new InvalidOperationException("Não foi possível obter o ID do usuário.");

    }
}
