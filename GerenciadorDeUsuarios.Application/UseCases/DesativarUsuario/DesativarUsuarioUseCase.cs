using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.DesativarUsuario;

public class DesativarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DesativarUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public void Executar(DesativarUsuarioRequest request)
    {
        var usuario = _usuarioRepository.ObterPorId(request.Id);
        if (usuario == null)
                throw new InvalidOperationException("Usuário não encontrado.");

        usuario.Desativar();
        _usuarioRepository.Atualizar(usuario);
    }
}
