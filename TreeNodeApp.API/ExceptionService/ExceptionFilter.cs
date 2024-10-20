using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TreeNodeApp.Core.Exceptions;

namespace TreeNodeApp.API.ExceptionService
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IExceptionService _exceptionService;

        public ExceptionFilter(IExceptionService exceptionService)
        {
            _exceptionService = exceptionService;
        }

        public void OnException(ExceptionContext context)
        {
            var eventId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            var ex = context.Exception;
            var exceptionType = ex is SecureException ? "Secure" : "Exception";
            var message = ex is SecureException ? ex.Message : $"Internal server error ID = {eventId}";

            // Логирование исключения
            _exceptionService.LogExceptionAsync(ex, context.HttpContext).Wait();

            var result = new JsonResult(new
            {
                type = exceptionType,
                id = eventId,
                data = new { message }
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
