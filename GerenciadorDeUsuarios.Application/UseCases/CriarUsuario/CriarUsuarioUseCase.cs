using GerenciadorDeUsuarios.Application.Interfaces;
using GerenciadorDeUsuarios.Domain.Entities;

namespace GerenciadorDeUsuarios.Application.UseCases.CriarUsuario;

public class CriarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CriarUsuarioUseCase(IUsuarioRepository usuarioRepository, 
        IPasswordHasher passwordHasher)
    {
        _usuarioRepository = usuarioRepository;
        _passwordHasher = passwordHasher;
    }

    public void Executar(CriarUsuarioRequest request)
    {
        if(_usuarioRepository.ExistePorEmail(request.Email))
            throw new InvalidOperationException("Já existe um usuário com este email.");
        
        var senhaHash = _passwordHasher.Hash(request.Senha);
        
        var usuario = Usuario.Criar(request.Nome, request.Email, senhaHash);
        _usuarioRepository.Adicionar(usuario);

    }

}
