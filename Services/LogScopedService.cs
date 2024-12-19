
using Interview.DependencyInjection.InterfacesDI;

namespace Interview.DependencyInjection.Services
{
    /// <summary>
    /// 
    /// Decorator Pattern In ASP.NET Core
    /// its a structural design pattern that allows you to introduce the new behavior to an existing class without modifying the original class in any way
    /// https://www.milanjovanovic.tech/blog/decorator-pattern-in-asp-net-core#how-to-implement-the-decorator-pattern
    /// </summary>
    public class LogScopedService : IScopedService
    {
        private readonly IScopedService _service;
        private readonly ILogger<LogScopedService> _logger;

        public LogScopedService(IScopedService service, ILogger<LogScopedService> logger)
        {
            _service = service;
            _logger = logger;
        }

        public Guid GetOperationId()
        {
            _logger.LogInformation("log scoped");
            return _service.GetOperationId();
        }
    }
}
