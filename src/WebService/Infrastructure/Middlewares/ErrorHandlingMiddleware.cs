using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Mmu.Khb.WebService.Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
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
                await WriteExceptionAsync(context, ex, HttpStatusCode.InternalServerError).ConfigureAwait(false);
            }
        }

        private static Exception UnwrapException(Exception exception)
        {
            while (true)
            {
                var result = exception;
                if (result.InnerException == null || !(exception is AggregateException))
                {
                    return result;
                }

                exception = result.InnerException;
            }
        }

        // Careful, these properties are expected form the client, do not change on only one side
        private static async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            exception = UnwrapException(exception);

            await response.WriteAsync(JsonConvert.SerializeObject(new { error = new { message = exception.Message, name = exception.GetType().Name, stack = exception.StackTrace } })).ConfigureAwait(false);
        }
    }
}