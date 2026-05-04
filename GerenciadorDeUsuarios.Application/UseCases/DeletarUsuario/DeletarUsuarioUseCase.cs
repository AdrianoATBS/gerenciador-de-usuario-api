using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.DeletarUsuario;

public class DeletarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DeletarUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public void Executar(DeletarUsuarioRequest request)
    {
        var usuario = _usuarioRepository.ObterPorId(request.Id);
        if(usuario == null)
            throw new InvalidOperationException("Usuário não encontrado.");
        _usuarioRepository.Deletar(usuario);
    }
}
