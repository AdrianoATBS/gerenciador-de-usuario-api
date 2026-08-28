using GerenciadorDeUsuarios.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeUsuarios.Infrastructure;
using GerenciadorDeUsuarios.Application;
using GerenciadorDeUsuarios.Infrastructure.Extensions;
using GerenciadorDeUsuarios.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddJwtAuthentication(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString
    ("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("Desenvolvimento", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });

});

var app = builder.Build();
app.UseCors("Desenvolvimento");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
