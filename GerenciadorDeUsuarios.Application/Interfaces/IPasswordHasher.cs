namespace GerenciadorDeUsuarios.Application.Interfaces;

public interface IPasswordHasher
{
    string Hash(string senha);
}
