using System.Security.Cryptography;
using System.Text;
using GerenciadorDeUsuarios.Application.Interfaces;

namespace GerenciadorDeUsuarios.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string senha)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(senha);
        var hashBytes = sha256.ComputeHash(bytes);

        return Convert.ToBase64String(hashBytes);


    }
}
