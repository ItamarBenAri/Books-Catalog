using System.Net;

namespace BooksCatalogModels
{
    public abstract class ClientException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        protected ClientException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class RouteNotFoundException : ClientException
    {
        public RouteNotFoundException(string route)
            : base($"Route '{route}' not found.", HttpStatusCode.NotFound)
        {
        }
    }

    public class ResourceNotFoundException : ClientException
    {
        public ResourceNotFoundException(string isbn)
            : base($"Isbn {isbn} does not exist.", HttpStatusCode.NotFound)
        {
        }
    }

    public class ValidationException : ClientException
    {
        public ValidationException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
