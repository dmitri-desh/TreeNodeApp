using Newtonsoft.Json;
using System.Net;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Core.Enums;
using TreeNodeApp.Core.Exceptions;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionLogRepository _exceptionLogRepository;

        public ExceptionHandlingMiddleware(RequestDelegate next, IExceptionLogRepository exceptionLogRepository)
        {
            _next = next;
            _exceptionLogRepository = exceptionLogRepository;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var eventId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            var exceptionType = ex is SecureException ? ExceptionType.SecureException : ExceptionType.Exception;
            var message = ex is SecureException ? ex.Message : $"Internal server error ID = {eventId}";

            var exceptionLog = new ExceptionLog
            {
                EventId = long.Parse(eventId),
                Timestamp = DateTime.UtcNow,
                Type = exceptionType,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                QueryParameters = context.Request.QueryString.ToString(),
                BodyParameters = await new StreamReader(context.Request.Body).ReadToEndAsync()
            };

            await _exceptionLogRepository.AddAsync(exceptionLog);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new
            {
                type = exceptionType.ToString(),
                id = eventId,
                data = new { message }
            });

            await context.Response.WriteAsync(result);
        }
    }
}
