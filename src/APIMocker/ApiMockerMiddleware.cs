namespace APIMocker
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class ApiMockerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApiMockerDispatcher _dispatcher;

        public ApiMockerMiddleware(RequestDelegate next, ApiMockerDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Si no tiene valor, que devuelva una lista de las posibles urls registradas

            //Si lo tiene, que lo busque.
            if (httpContext.Request.Path.HasValue)
            {
                var result = _dispatcher.Resolve(httpContext.Request.Path.Value);
                await WriteResultInResponse(httpContext, result);
            }
        }

        private async Task WriteResultInResponse(HttpContext httpContext, ApiMockerResult result)
        {
            httpContext.Response.StatusCode = result.StatusCode;
            httpContext.Response.ContentType = result.ContentType;
            await HttpResponseWritingExtensions.WriteAsync(httpContext.Response, result.Content);
        }
    }

    
}