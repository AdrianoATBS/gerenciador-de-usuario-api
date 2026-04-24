using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.AlterarNome;

public class AlterarNomeUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AlterarNomeUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public void Executar(AlterarNomeRequest request)
    {
       var usuario = _usuarioRepository.ObterPorId(request.Id);

        if (usuario == null)
            throw new InvalidOperationException("Usuário não encontrado.");
       
        usuario.AlterarNome(request.Nome);
        _usuarioRepository.Atualizar(usuario);
    }
}
