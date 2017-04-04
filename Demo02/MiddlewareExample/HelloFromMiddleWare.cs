using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Demo02.MiddlewareExample
{
    public class HelloFromMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public HelloFromMiddleWare(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;

            //TODO: 5.2 add logger to Custom middleware
            _logger = loggerFactory.CreateLogger<HelloFromMiddleWare>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogWarning("Hello world, I'm listening...");
            await _next.Invoke(httpContext);
        }

    }
}
