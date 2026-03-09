using System.Text.Json;

namespace TodoApi.WebApi.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var payload = new { message = "An unexpected error occurred.", detail = ex.Message };
            await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
        }
    }
}
