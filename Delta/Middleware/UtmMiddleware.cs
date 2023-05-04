using Delta.Models;

namespace Delta.Middleware;

public class UtmMiddleware
{
    private readonly RequestDelegate _next;

    public UtmMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var utm = new UtmModel
        {
            Source = context.Request.Query["utm_source"]!,
            Medium = context.Request.Query["utm_medium"]!,
            Campaign = context.Request.Query["utm_campaign"]!
        };

        var utmString = utm.GetUtmString();

        if (!string.IsNullOrEmpty(utmString))
        {
            context.Response.Cookies.Append("utm_info", utmString, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(14)
            });
        }

        await _next(context);
    }
}

public static class UtmMiddlewareExtensions
{
    public static IApplicationBuilder UseUtm(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UtmMiddleware>();
    }
}