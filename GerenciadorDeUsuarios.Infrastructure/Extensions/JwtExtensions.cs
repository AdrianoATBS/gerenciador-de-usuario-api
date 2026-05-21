using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorDeUsuarios.Infrastructure.Extensions;

public static class JwtExtensions
{
    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var chaveSecreta = configuration["JwtSettings:SecretKey"];
        var chave = Encoding.ASCII.GetBytes(chaveSecreta!);

        services.AddAuthentication(x =>
         {
            x.DefaultAuthenticateScheme = 
                JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = 
                JwtBearerDefaults.AuthenticationScheme;
         })

        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(chave),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });
        return services;
    }
}
