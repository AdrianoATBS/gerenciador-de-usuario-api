using GerenciadorDeUsuarios.Application.Interfaces;
using GerenciadorDeUsuarios.Application.UseCases.AlterarEmail;
using GerenciadorDeUsuarios.Application.UseCases.AlterarNome;
using GerenciadorDeUsuarios.Application.UseCases.CriarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DeletarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DesativarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.LoginUsuario;
using GerenciadorDeUsuarios.Application.UseCases.ReativarUsuario;
using GerenciadorDeUsuarios.Infrastructure.Data;
using GerenciadorDeUsuarios.Infrastructure.Repositories;
using GerenciadorDeUsuarios.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gerenciador de Usuariios" +
        "API",
        Version = "v1"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {seu token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    
});

builder.Services.AddScoped<CriarUsuarioUseCase>();
builder.Services.AddScoped<AlterarEmailUseCase>();
builder.Services.AddScoped<AlterarNomeUseCase>();
builder.Services.AddScoped<DesativarUsuarioUseCase>();
builder.Services.AddScoped<ReativarUsuarioUseCase>();
builder.Services.AddScoped<DeletarUsuarioUseCase>();
builder.Services.AddScoped<LoginUsuarioUseCase>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString));
var  chaveSecreta = builder.Configuration["JwtSettings:SecretKey"];
var chave = Encoding.ASCII.GetBytes(chaveSecreta);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
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

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
