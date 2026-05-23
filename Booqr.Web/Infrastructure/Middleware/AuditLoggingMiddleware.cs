using System.Net;
using Booqr.Logic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Booqr.Web.Infrastructure.Middleware;

public class AuditLoggingMiddleware
{
    private readonly RequestDelegate _next;

    private static readonly string[] _stateChangingMethods = ["POST", "PUT", "DELETE"];

    public AuditLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (_stateChangingMethods.Contains(context.Request.Method))
        {
            try
            {
                var auditService = context.RequestServices.GetRequiredService<IAuditService>();

                var userName = context.User.Identity?.Name ?? "Anonymous";
                var path = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
                var timestampUtc = DateTime.UtcNow;

                await auditService.LogAsync(userName, path, context.Request.Method, timestampUtc);
            }
            catch
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
