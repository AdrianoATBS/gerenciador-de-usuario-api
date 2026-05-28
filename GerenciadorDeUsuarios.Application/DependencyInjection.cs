using System.Collections.ObjectModel;
using GerenciadorDeUsuarios.Application.UseCases.AlterarEmail;
using GerenciadorDeUsuarios.Application.UseCases.AlterarNome;
using GerenciadorDeUsuarios.Application.UseCases.BuscarTodosOsUsuarios;
using GerenciadorDeUsuarios.Application.UseCases.CriarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DeletarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DesativarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.LoginUsuario;
using GerenciadorDeUsuarios.Application.UseCases.ReativarUsuario;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeUsuarios.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<CriarUsuarioUseCase>();
        services.AddScoped<AlterarEmailUseCase>();
        services.AddScoped<AlterarNomeUseCase>();
        services.AddScoped<DesativarUsuarioUseCase>();
        services.AddScoped<ReativarUsuarioUseCase>();
        services.AddScoped<DeletarUsuarioUseCase>();
        services.AddScoped<LoginUsuarioUseCase>();
        services.AddScoped<ObterUsuarioUseCase>();
        return services;
    }

  

}
