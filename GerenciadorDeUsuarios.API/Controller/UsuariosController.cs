using GerenciadorDeUsuarios.Application.UseCases.AlterarEmail;
using GerenciadorDeUsuarios.Application.UseCases.AlterarNome;
using GerenciadorDeUsuarios.Application.UseCases.CriarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DesativarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.ReativarUsuario;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeUsuarios.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly CriarUsuarioUseCase _criarUsuario;
    private readonly AlterarNomeUseCase _alterarNome;
    private readonly AlterarEmailUseCase _alterarEmail;
    private readonly DesativarUsuarioUseCase _desativarUsuario;
    private readonly ReativarUsuarioUseCase _reativarUsuario;
    public UsuariosController(CriarUsuarioUseCase criarUsuario
        , AlterarNomeUseCase alterarNome, AlterarEmailUseCase alterarEmail,
        DesativarUsuarioUseCase desativarUsuario, ReativarUsuarioUseCase
        reativarUsuario)
    {
        _criarUsuario = criarUsuario;
        _alterarNome = alterarNome;
        _alterarEmail = alterarEmail;
        _desativarUsuario = desativarUsuario;
        _reativarUsuario = reativarUsuario;
    }

    [HttpPost]
    public IActionResult CriarUsuario(CriarUsuarioRequest request)
    {
        _criarUsuario.Executar(request);
        return Ok("Usuário criado com sucesso!");
    }

    [HttpPut("nome")]
    public IActionResult AlterarNome(AlterarNomeRequest request)
    {
        _alterarNome.Executar(request);
        return Ok("Nome do usuário alterado com sucesso!");
    }

    [HttpPut("email")]
    public IActionResult AlterarEmail(AlterarEmailRequest request)
    {
        _alterarEmail.Executar(request);
        return Ok("Email do usuário alterado com sucesso!");
    }
    [HttpPut("desativar")]
    public IActionResult DesativarUsuario(DesativarUsuarioRequest request)
    {
        _desativarUsuario.Executar(request);
        return Ok("Usuário desativado com sucesso!");
    }
    [HttpPut("reativar")]
    public IActionResult ReativarUsuario(ReativarUsuarioRequest request)
    {
        _reativarUsuario.Executar(request);
        return Ok("Usuário reativado com sucesso!");

    }
}