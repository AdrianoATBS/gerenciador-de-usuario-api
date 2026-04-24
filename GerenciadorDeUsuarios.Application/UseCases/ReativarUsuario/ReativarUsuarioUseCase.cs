using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.ReativarUsuario;

public class ReativarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ReativarUsuarioUseCase(IUsuarioRepository usuariosRepository)
    {
        _usuarioRepository = usuariosRepository;
    }

    public void Executar(ReativarUsuarioRequest request)
    {
        var usuario = _usuarioRepository.ObterPorId(request.Id);

        if(usuario == null)
            throw new InvalidOperationException("Usuário não encontrado.");

        usuario.Reativar();
        _usuarioRepository.Atualizar(usuario);


    }
}
