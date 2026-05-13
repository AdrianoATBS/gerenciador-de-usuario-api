using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.LoginUsuario;

public class LoginUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;
    public LoginUsuarioUseCase(IUsuarioRepository usuarioRepository,
        IPasswordHasher passwordHasher, ITokenService tokenService)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public string Executar(LoginUsuarioRequest request)
    {
        var usuario = _usuarioRepository.ObterPorEmail(request.Email);
        if (usuario == null)
                throw new InvalidOperationException("Usuário não encontrado.");
        
        var senhaValida = _passwordHasher.Verificar(request.Senha, usuario.SenhaHash);
        if(!senhaValida)
            throw new InvalidOperationException("Senha incorreta.");

        var token = _tokenService.GerarToken(usuario);
        return token;

    }

}
