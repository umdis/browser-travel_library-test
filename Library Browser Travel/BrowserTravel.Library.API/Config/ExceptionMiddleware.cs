using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BrowserTravel.Library.API.Config
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        /// <summary>
        /// Allows global exception catching
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"");
                await HandleGlobalExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Returns a response detailing the exception
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static Task HandleGlobalExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;

            return httpContext.Response.WriteAsJsonAsync(new
            {
                Statuscode = StatusCodes.Status409Conflict,
                Message = "¡Se produjo una operación inesperada!",
                ex.StackTrace
            });
        }
    }
}
