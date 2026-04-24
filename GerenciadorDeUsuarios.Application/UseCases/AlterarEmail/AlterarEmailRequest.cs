namespace GerenciadorDeUsuarios.Application.UseCases.AlterarEmail;

public class AlterarEmailRequest
{
    public Guid Id { get; set; }
    public string NovoEmail { get; set; } = string.Empty;

}
