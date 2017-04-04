using Microsoft.AspNetCore.Builder;

namespace Demo02.MiddlewareExample
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseHelloFromMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<HelloFromMiddleWare>();
        }
    }
}
