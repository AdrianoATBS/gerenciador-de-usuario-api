using GerenciadorDeUsuarios.Application.DTO;

namespace GerenciadorDeUsuarios.Application.Interfaces;

public interface IUserContext
{
    UsuarioAutenticado ObterUsuarioAutenticado();

};
