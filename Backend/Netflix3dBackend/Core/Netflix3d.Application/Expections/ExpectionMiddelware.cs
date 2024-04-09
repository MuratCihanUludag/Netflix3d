using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using FluentValidation;
namespace Netflix3d.Application.Expections
{
    public class ExpectionMiddelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
                // httpContext.Response.ContentType = "application/json";
            }
            catch (Exception ex)
            {
                await HandleExpectionAsync(httpContext, ex);
            }
        }
        private static Task HandleExpectionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatsusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(v => v.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
            }


            List<string> errors = new()
            {
               $"Error Message : {exception.Message}",
               $"Error InnerExpection {exception.InnerException.ToString()}"
            };
            return httpContext.Response.WriteAsJsonAsync(new ExceptionModel { StatusCode = statusCode, Errors = errors }.ToString());
        }
        private static int GetStatsusCode(Exception exception) =>
            exception switch
            {
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                DirectoryNotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
