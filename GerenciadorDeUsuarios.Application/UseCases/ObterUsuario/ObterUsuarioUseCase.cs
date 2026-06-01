using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.BuscarTodosOsUsuarios;

public class ObterUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public ObterUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public ObterUsuarioResponse Executar(ObterUsuarioRequest request)
    {
        var usuario = _usuarioRepository.ObterPorId(request.Id);
        if (usuario == null)
            throw new InvalidOperationException("Usuário não encontrado.");

        return new ObterUsuarioResponse 
        {
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }
}
