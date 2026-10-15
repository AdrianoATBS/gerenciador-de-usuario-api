using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.ObterUsuarioJWT;

public class ObterUsuarioJWTUseCase
{
    private readonly IUserContext _userContext;
    private readonly IUsuarioRepository _usuarioRepository;
    public ObterUsuarioJWTUseCase(IUserContext userContext, IUsuarioRepository usuarioRepository)
    {
        _userContext = userContext;
        _usuarioRepository = usuarioRepository;
    }
    public ObterUsuarioJWTResponse Executar()
    {
        var usuarioId= _userContext.ObterUsuarioAutenticado();

        var buscarUsuario = _usuarioRepository.ObterPorId(usuarioId.Id);
        if(buscarUsuario == null)
            throw new Exception("Usuário não encontrado.");

        return new ObterUsuarioJWTResponse
        {
            Id = buscarUsuario.Id,
            Nome = buscarUsuario.Nome,
            Email = buscarUsuario.Email,
            CriadoEm = buscarUsuario.CriadoEm.ToString("yyyy-MM-dd HH:mm:ss")
        };
    }
}
