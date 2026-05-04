using GerenciadorDeUsuarios.Domain.Entities;

namespace GerenciadorDeUsuarios.Application.Interfaces;

public interface IUsuarioRepository
{
    void Adicionar(Usuario usuario);
    void Atualizar(Usuario usuario);
    void Deletar(Usuario usuario);
    bool ExistePorEmail(string email);
    bool EmailJaUsadoPorOutroUsuario(string email, Guid id);
    Usuario? ObterPorId(Guid id);

}
