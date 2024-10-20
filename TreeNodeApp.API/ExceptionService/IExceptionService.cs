namespace TreeNodeApp.API.ExceptionService
{
    public interface IExceptionService
    {
        Task LogExceptionAsync(Exception exception, HttpContext context);
    }
}
