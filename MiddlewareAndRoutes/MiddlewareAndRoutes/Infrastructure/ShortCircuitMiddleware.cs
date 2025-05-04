using System.Text;

namespace MiddlewareAndRoutes.Infrastructure;

public class ShortCircuitMiddleware
{
    private readonly RequestDelegate _nextDelegate;
    public ShortCircuitMiddleware(RequestDelegate next) => _nextDelegate = next;

    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Headers.UserAgent.Any(h => h.ToLower().Contains("gecko-version")))
            httpContext.Response.StatusCode = 403;
        else
            await _nextDelegate.Invoke(httpContext);
    }
}