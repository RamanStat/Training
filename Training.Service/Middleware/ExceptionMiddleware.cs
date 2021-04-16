using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Training.Service.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;

        public ExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception exception)
            {
                switch (exception)
                {
                    case var _ when exception is ValidationException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.Response.WriteAsJsonAsync(exception.Message);
                        break;
                    default:
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsJsonAsync(exception.Message);
                        break;
                }
            }
        }
    }
}
