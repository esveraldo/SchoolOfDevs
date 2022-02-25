using Microsoft.AspNetCore.Http;
using SchoolOfDevs.Exceptions;
using System.Net;
using System.Text.Json;

namespace SchoolOfDevs.Middleware
{
    public class ErrorHandlerMiddlewate
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddlewate(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = error switch
                {
                    BadRequestException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    ForbbidenException => (int)HttpStatusCode.Forbidden,

                    _ => (int)HttpStatusCode.InternalServerError,
                };
                var result = JsonSerializer.Serialize(new { Message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
