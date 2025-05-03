namespace Application.Utilities.AttributeFilters
{
    public class LoggerCustomAttribute : ExceptionFilterAttribute, IAsyncResultFilter
    {
        public LoggerCustomAttribute()
        {
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next(); // this calls the action method
        }

        public override void OnException(ExceptionContext context)
        {
            var currentUsername = context.HttpContext is not null && !string.IsNullOrEmpty(context.HttpContext.User?.Identity?.Name)
              ? context.HttpContext.User?.Identity?.Name
              : "Anonymous";

            var path = $"{context?.HttpContext?.Request?.Scheme}://{context?.HttpContext?.Request?.Host}{context?.HttpContext?.Request?.Path.ToString().TrimEnd('/')}{context?.HttpContext?.Request?.QueryString}";

            var logRepository = context.HttpContext.RequestServices.GetService<IGenericRepository<Logger>>();

            logRepository.Add(new Logger()
            {
                Id = Guid.NewGuid().ToString(),
                TraceId = context?.HttpContext?.TraceIdentifier,
                Page = context.RouteData?.Values["Page"]?.ToString(),
                Handler = context?.HttpContext?.Request?.Query["handler"].Count > 0 ? context?.HttpContext?.Request?.Query["handler"].ToString() : null,
                IP = context?.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                LogType = LogType.Error,
                Path = path,
                StatusCode = 500,
                UserName = currentUsername,
                Message = context.Exception.Message,
                CreateDate = DateTime.Now,
            });

            logRepository.Save();
        }

    }

    public class SkipLoggingAttribute : Attribute
    {
    }
}
