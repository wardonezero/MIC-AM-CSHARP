using System.Text;

namespace MiddlewareAndRoutes.Infrastructure;
public class ContentMiddleware
{
    private readonly RequestDelegate _nextDelegate;
    public ContentMiddleware(RequestDelegate next) => _nextDelegate = next;

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            await httpContext.Response.WriteAsync("This is from the content middleware", Encoding.UTF8);
        else
            await _nextDelegate.Invoke(httpContext);
    }
}