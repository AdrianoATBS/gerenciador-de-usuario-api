using System.Net.Mail;
namespace GerenciadorDeUsuarios.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string SenhaHash { get; private set; } = string.Empty;
    public DateTime CriadoEm { get; private set; }
    public bool IsAtivo { get; private set; }
    private Usuario(string nome, string email, string senhaHash, DateTime criadoEm
        )
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        CriadoEm = criadoEm;
        IsAtivo = true;
    }

    public static Usuario Criar(string nome, string email, string senhaHash)
    {

        ValidarNome(nome);
        ValidarEmail(email);
        ValidarSenhaHash(senhaHash);
        return new Usuario(nome, email, senhaHash, DateTime.UtcNow);
    }

     public void Desativar()
    {
        if(!IsAtivo)
            throw new InvalidOperationException("O usuário já está desativado.");
        IsAtivo = false;
    }
    public void Reativar()
    {
        if (IsAtivo)
            throw new InvalidOperationException("O usuário já está ativo.");
        IsAtivo = true;
    }

    public void AlterarNome(string novoNome)
    {
        if(!IsAtivo)
            throw new InvalidOperationException("O usuário está desativado.");
   
        
        if (Normalizar(novoNome) == Normalizar(Nome))
            throw new InvalidOperationException("O nome é igual ao atual.");

        ValidarNome(novoNome);

        Nome = novoNome;

    }
    public void AlterarEmail(string novoEmail)
    {
        if (!IsAtivo)
            throw new InvalidOperationException("O usuário está desativado.");
        
        if (Normalizar(novoEmail) == Normalizar(Email))
            throw new InvalidOperationException("O email é igual ao atual.");
       
        ValidarEmail(novoEmail);
        Email = novoEmail;
    }
    public void AlterarSenhaHash(string novaSenhaHash)
    {
        if (!IsAtivo)
            throw new InvalidOperationException("O usuário está desativado.");
        
        if (novaSenhaHash == SenhaHash)
            throw new InvalidOperationException("A senha hash é igual a atual.");

        ValidarSenhaHash(novaSenhaHash);

        SenhaHash = novaSenhaHash;
    }

    private static void ValidarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("O nome é obrigatório.", nameof(novoNome));
        if (novoNome.Length < 3) throw new ArgumentException("Nome menor que 3 caracteres");
        
    }
    private static void ValidarEmail(string novoEmail)
    {
        if (string.IsNullOrEmpty(novoEmail))
            throw new ArgumentException("O email não pode ser vazio.", nameof(novoEmail));
        if (!string.IsNullOrWhiteSpace(novoEmail) &&
            !MailAddress.TryCreate(novoEmail, out _))
            throw new ArgumentException("O email válido é obrigatorio.");
    }
    private static void ValidarSenhaHash(string novaSenhaHash)
    {
        if (string.IsNullOrWhiteSpace(novaSenhaHash))
            throw new ArgumentException("A senha não pode ser vazia.", 
                nameof(novaSenhaHash));
    }

    private static string Normalizar(string valor)
    {
        if(string.IsNullOrWhiteSpace(valor))
            return string.Empty;
       return valor.Trim().ToLower();
    }



}
