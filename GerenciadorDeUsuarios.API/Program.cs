using GerenciadorDeUsuarios.Application.Interfaces;
using GerenciadorDeUsuarios.Application.UseCases.AlterarEmail;
using GerenciadorDeUsuarios.Application.UseCases.AlterarNome;
using GerenciadorDeUsuarios.Application.UseCases.CriarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.DesativarUsuario;
using GerenciadorDeUsuarios.Application.UseCases.ReativarUsuario;
using GerenciadorDeUsuarios.Infrastructure.Data;
using GerenciadorDeUsuarios.Infrastructure.Repositories;
using GerenciadorDeUsuarios.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CriarUsuarioUseCase>();
builder.Services.AddScoped<AlterarEmailUseCase>();
builder.Services.AddScoped<AlterarNomeUseCase>();
builder.Services.AddScoped<DesativarUsuarioUseCase>();
builder.Services.AddScoped<ReativarUsuarioUseCase>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
