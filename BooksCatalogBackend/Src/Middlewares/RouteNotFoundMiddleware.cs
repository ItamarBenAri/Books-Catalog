using BooksCatalogModels;

namespace BooksCatalogBackend.Src.Middlewares
{
    public class RouteNotFoundMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public RouteNotFoundMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {
                _logger.LogError("Error: {Message}", "Route Not Found");

                throw new RouteNotFoundException(context.Request.Path);
            }
        }
    }
}
