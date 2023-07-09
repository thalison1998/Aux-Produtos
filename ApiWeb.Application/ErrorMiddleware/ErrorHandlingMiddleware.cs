using ApiWeb.Application.ErrorMiddleware;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            ProblemDetails problemDetails = null;

            switch (ex)
            {
                case NotFoundException notFoundEx:
                    problemDetails = new ProblemDetails()
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Title = "Entidade não encontrada",
                        Detail = notFoundEx.Message,
                        Instance = context.Request.Path,
                    };
                    break;
                case ValidationException validationEx:
                    var errors = validationEx.Errors.Select(e => new { Property = e.PropertyName, Message = e.ErrorMessage });
                    problemDetails = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = "Bad Request",
                        Detail = "Um ou mais erros de validação ocorreram.",
                        Instance = context.Request.Path,
                    };
                    
                    problemDetails.Extensions.Add("errors", errors);
                    break;
                default:
                    problemDetails = new ProblemDetails()
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Title = "Erro interno do servidor",
                        Detail = ex.InnerException?.Message,
                        Instance = context.Request.Path,
                    };
                    break;
            }

            await HandleExceptionAsync(context, problemDetails);
        }

    }

    private Task HandleExceptionAsync(HttpContext context, ProblemDetails ex)
    {
        context.Response.StatusCode = (int)ex.Status;

        context.Response.ContentType = "application/problem+json";

        return context.Response.WriteAsync(JsonConvert.SerializeObject(ex));
    }
}

