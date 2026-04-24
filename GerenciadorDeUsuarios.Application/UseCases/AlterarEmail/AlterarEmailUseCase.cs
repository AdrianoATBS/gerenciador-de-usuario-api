using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Application.UseCases.AlterarEmail;

public class AlterarEmailUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AlterarEmailUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public void Executar(AlterarEmailRequest request)
    {
        var usuario = _usuarioRepository.ObterPorId(request.Id);

        if (usuario == null)
            throw new InvalidOperationException("Usuário não encontrado.");
       
        if(_usuarioRepository.EmailJaUsadoPorOutroUsuario(request.NovoEmail, request.Id))
            throw new InvalidOperationException("Já existe um usuário com este email.");

        usuario.AlterarEmail(request.NovoEmail);

        _usuarioRepository.Atualizar(usuario);
    }

}
