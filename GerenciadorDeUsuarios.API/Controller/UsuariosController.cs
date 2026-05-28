using Azure.Core;
using GerenciadorDeUsuarios.Application.UseCases.AlterarEmail;
using GerenciadorDeUsuarios.Application.UseCases.AlterarNome;
using GerenciadorDeUsuarios.Application.UseCases.BuscarTodosOsUsuarios;
using GerenciadorDeUsuarios.Application.UseCases.CriarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DeletarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DesativarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.LoginUsuario;
using GerenciadorDeUsuarios.Application.UseCases.ReativarUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeUsuarios.API.Controller;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsuariosController : ControllerBase
{
    private readonly CriarUsuarioUseCase _criarUsuario;
    private readonly AlterarNomeUseCase _alterarNome;
    private readonly AlterarEmailUseCase _alterarEmail;
    private readonly DesativarUsuarioUseCase _desativarUsuario;
    private readonly ReativarUsuarioUseCase _reativarUsuario;
    private readonly DeletarUsuarioUseCase _deletarUsuario;
    private readonly LoginUsuarioUseCase _loginUsuario;
    private readonly ObterUsuarioUseCase _obterUsuario;
    public UsuariosController(CriarUsuarioUseCase criarUsuario
        , AlterarNomeUseCase alterarNome, AlterarEmailUseCase alterarEmail,
        DesativarUsuarioUseCase desativarUsuario, ReativarUsuarioUseCase
        reativarUsuario, DeletarUsuarioUseCase deletarUsuario,
        LoginUsuarioUseCase loginUsuario, ObterUsuarioUseCase obterUsuario)
    {
        _criarUsuario = criarUsuario;
        _alterarNome = alterarNome;
        _alterarEmail = alterarEmail;
        _desativarUsuario = desativarUsuario;
        _reativarUsuario = reativarUsuario;
        _deletarUsuario = deletarUsuario;
        _loginUsuario = loginUsuario;
        _obterUsuario = obterUsuario;
    }
    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginUsuarioRequest request)
    {
        var token = _loginUsuario.Executar(request);
        return Ok(new
        {
            AccessToken = token,
            tokenType = "Bearer",
            Expiraem = 3600
        });
    }
    [AllowAnonymous]
    [HttpPost]
    public IActionResult CriarUsuario(CriarUsuarioRequest request)
    {
        _criarUsuario.Executar(request);
        return Created(string.Empty, new { message = "Usuário criado com sucesso"});
    }
    [HttpGet("{id}")]
    public IActionResult ObterUsuario(Guid id)
    {
       var response = _obterUsuario.Executar(new ObterUsuarioRequest 
       { 
           Id =  id
       });
        return Ok(response);

    }

    [HttpPut("nome")]
    public IActionResult AlterarNome(AlterarNomeRequest request)
    {
        _alterarNome.Executar(request);
        return Ok(new { message = "Nome do usuário alterado com sucesso! "});
    }

    [HttpPut("email")]
    public IActionResult AlterarEmail(AlterarEmailRequest request)
    {
        _alterarEmail.Executar(request);
        return Ok(new { message = "Email do usuário alterado com sucesso!"});
    }
    [HttpPut("desativar")]
    public IActionResult DesativarUsuario(DesativarUsuarioRequest request)
    {
        _desativarUsuario.Executar(request);
        return NoContent();
    }
    [HttpPut("reativar")]
    public IActionResult ReativarUsuario(ReativarUsuarioRequest request)
    {
        _reativarUsuario.Executar(request);
        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult DeletarUsuario(Guid id)
    {
        _deletarUsuario.Executar(new DeletarUsuarioRequest { Id = id });
        return NoContent();
    }
}