namespace Application.Utilities.AttributeFilters
{
    public class LoggerCustomAttribute : ExceptionFilterAttribute, IAsyncResultFilter
    {
        public LoggerCustomAttribute()
        {
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
        }

        public override void OnException(ExceptionContext context)
        {
            // Logging logic
        }

    }

    public class SkipLoggingAttribute : Attribute
    {
    }
}
