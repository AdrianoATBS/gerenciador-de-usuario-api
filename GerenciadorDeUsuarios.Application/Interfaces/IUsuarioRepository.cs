using GerenciadorDeUsuarios.Domain.Entities;

namespace GerenciadorDeUsuarios.Application.Interfaces;

public interface IUsuarioRepository
{
    void Adicionar(Usuario usuario);
    bool ExistePorEmail(string email);
}
