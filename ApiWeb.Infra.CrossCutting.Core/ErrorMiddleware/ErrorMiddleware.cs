
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApiWeb.Infra.CrossCutting.Core.ErrorMiddleware;
public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var statusCode = GetStatusCode(ex);
        var response = new ErrorResponse(statusCode, ex.Message);
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }

    private static int GetStatusCode(Exception ex)
    {
        switch (ex)
        {
            case BadHttpRequestException:
                return StatusCodes.Status400BadRequest;
            case UnauthorizedAccessException:
                return StatusCodes.Status401Unauthorized;
            case NotFoundException:
                return StatusCodes.Status404NotFound;
            case InvalidOperationException:
                return StatusCodes.Status409Conflict;
            default:
                return StatusCodes.Status500InternalServerError;
        }
    }
}
