using BooksCatalogModels;
using System.Net;
using System.Text.Json;

namespace BooksCatalogBackend.Src.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ClientException ex)
            {
                _logger.LogError("Error: {Message}", ex.Message);

                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    error = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong, try again later.");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    error = "Something went wrong, try again later.",
                    details = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
