using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.ObterUsuarioJWT;

public class ObterUsuarioJWTUseCase
{
    private readonly IUserContext _userContext;
    public ObterUsuarioJWTUseCase(IUserContext userContext)
    {
        _userContext = userContext;
    }
    public ObterUsuarioJWTResponse Executar()
    {
        var usuarioId = _userContext.ObterUsuarioAutenticado();


        return new ObterUsuarioJWTResponse
        {
            Nome = usuarioId.Nome,
            Email = usuarioId.Email
        };
    }
}
