using Microsoft.AspNetCore.Mvc.Filters;
using UserManagement.core.extensions;

namespace UserManager.api.filters;

public class LogRequestHeaderActionFilter : ActionFilterAttribute
{
    private readonly ILogger<LogRequestHeaderActionFilter> _logger;

    public LogRequestHeaderActionFilter(ILogger<LogRequestHeaderActionFilter> logger)
    {
        _logger = logger;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var h = new
        {
            context.HttpContext.Request.Headers.Authorization,
            context.HttpContext.Request.Headers.Accept,
            context.HttpContext.Request.Headers.ContentType,
            context.HttpContext.Request.Headers.AcceptLanguage,
            context.HttpContext.Request.Headers.UserAgent,
            RemoteIp = context.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
            LocalIp= context.HttpContext?.Connection?.LocalIpAddress?.ToString()
            
        };
        var headerData = new
        {
            method = context.HttpContext.Request.Method,
            headers = h.ToJson()
        };
        
        // Log details here
        _logger.LogInformation("Request Headers for RequestType : {headerData}", headerData);
        base.OnActionExecuting(context);
    }
}
