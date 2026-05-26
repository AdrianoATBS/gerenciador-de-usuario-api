using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GerenciadorDeUsuarios.Infrastructure.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    
    public ExceptionMiddleware(RequestDelegate next, 
        ILogger<ExceptionMiddleware> logger
        )
    {
        _next = next;
        _logger = logger;
    }
    
   
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ArgumentException ex)
        { 
            await HandleExceptionAsync(context, ex);
        }
        
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statucCode, title, detail, isCritical) = exception switch
        {
            ArgumentException =>
            (
            StatusCodes.Status400BadRequest,
            "Ocorreu um erro de argumento inválido",
            exception.Message,
            true
            ),
            InvalidOperationException => (
            StatusCodes.Status409Conflict,
            "Conflito na operação",
            exception.Message,
            false
            ),
            _ => (
            StatusCodes.Status500InternalServerError,
            "Ocorreu um erro inesperado",
            "Por favor, tente novamente mais tarde ou contate o suporte",
            true
            )
        };

        if(isCritical)
        {
            _logger.LogError(exception, "Erro crítico detectado na rota {Path}: {Message}", context.Request.Path.Value, exception.Message);

        }
        else
        {
            _logger.LogWarning(exception, "Conflito detectado na rota {Path}: {Message}", context.Request.Path.Value, exception.Message);
        }

        context.Response.StatusCode = statucCode;
        context.Response.ContentType = "application/json";
        
        await context.Response.WriteAsJsonAsync(new
        {
            type = $"https://httpstatuses.com/{statucCode}",
            title,
            status = statucCode,
            detail,
            instance = context.Request.Path.Value
        });
    }
    
}   
