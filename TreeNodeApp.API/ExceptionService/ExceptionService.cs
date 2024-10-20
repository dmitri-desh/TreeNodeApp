using Newtonsoft.Json;
using System.Net;
using TreeNodeApp.Application.Interfaces;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Core.Enums;
using TreeNodeApp.Core.Exceptions;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.API.ExceptionService
{
    public class ExceptionService : IExceptionService
    {
        private readonly IExceptionLogRepository _exceptionLogRepository;

        public ExceptionService(IExceptionLogRepository exceptionLogRepository)
        {
            _exceptionLogRepository = exceptionLogRepository;
        }

        public async Task LogExceptionAsync(Exception exception, HttpContext context)
        {
            var eventId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            var exceptionType = exception is SecureException ? ExceptionType.SecureException : ExceptionType.Exception;
            var message = exception is SecureException ? exception.Message : $"Internal server error ID = {eventId}";

            var exceptionLog = new ExceptionLog
            {
                EventId = long.Parse(eventId),
                Timestamp = DateTime.UtcNow,
                Type = exceptionType,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
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
