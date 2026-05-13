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

    public bool Verificar(string senha, string senhaHash)
    {
        var hashDaSenha = Hash(senha);
        byte[] bytesDoHashGerado = Encoding.UTF8.GetBytes(hashDaSenha);
        byte[] bytesDoHashDoBanco = Encoding.UTF8.GetBytes(senhaHash);

        return CryptographicOperations.FixedTimeEquals(bytesDoHashGerado, bytesDoHashDoBanco);
    }
}
