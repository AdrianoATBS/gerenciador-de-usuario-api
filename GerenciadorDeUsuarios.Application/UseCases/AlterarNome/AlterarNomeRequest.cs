namespace GerenciadorDeUsuarios.Application.UseCases.AlterarNome;

public class AlterarNomeRequest
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
