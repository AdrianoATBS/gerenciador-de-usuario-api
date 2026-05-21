using GerenciadorDeUsuarios.Application.Interfaces;
using GerenciadorDeUsuarios.Infrastructure.Repositories;
using GerenciadorDeUsuarios.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeUsuarios.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure
        (this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITokenService, JwtTokenService>();
        return services;
    }

}
