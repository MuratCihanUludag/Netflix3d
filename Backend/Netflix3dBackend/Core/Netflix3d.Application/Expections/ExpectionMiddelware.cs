using Microsoft.AspNetCore.Http;
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
               $"Error Message : {exception.Message}"
            };
            return httpContext.Response.WriteAsJsonAsync(new ExceptionModel { StatusCode = statusCode, Errors = errors });
        }
        private static int GetStatsusCode(Exception exception) =>
            exception switch
            {
                BadHttpRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
