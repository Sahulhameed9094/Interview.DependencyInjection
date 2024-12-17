using Interview.DependencyInjection.InterfacesDI;
using Interview.DependencyInjection.Models;
using Interview.DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interview.DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// New instance for every injection
        /// Each time a transient service is requested, a new instance is created, even in the same API request.
        /// </summary>
        private readonly ITransientService _transientService;
        private readonly ITransientService _transientService2;


        /// <summary>
        /// One instance per HTTP request
        /// Scoped services are created once per request. The same instance is shared throughout the lifetime of a single HTTP request.
        /// </summary>
        private readonly IScopedService _scopedService;
        private readonly IScopedService _scopedService2;

        /// <summary>
        /// SIngle instance for entire application lifcycle
        /// </summary>
        private readonly ISingletonService _singletonService;
        private readonly ISingletonService _singletonService2;


        public HomeController(ILogger<HomeController> logger,
                              IScopedService scopedService,
                              ITransientService transientService,
                              ISingletonService singletonService,
                              ITransientService transientService2,
                              IScopedService scopedService2,
                              ISingletonService singletonService2)
        {
            _logger = logger;
            _scopedService = scopedService;
            _transientService = transientService;
            _singletonService = singletonService;
            _transientService2 = transientService2;
            _scopedService2 = scopedService2;
            _singletonService2 = singletonService2;
        }

        public IActionResult Index()
        {
            return Content($"New instance for every injection \n" +
                $"Transient intance:{_transientService.GetOperationId()}\n"
                        + $"Transient intance:{_transientService2.GetOperationId()}\n"
                        + "\n"
                        + "new instance per http request \n"
                        + $"Scoped intance:{_scopedService.GetOperationId()}\n"
                        + $"Scoped intance:{_scopedService2.GetOperationId()}\n"
                         + "\n"
                          + "single instance for entire application life cycle\n"
                        + $"Singleton intance:{_singletonService.GetOperationId()}\n"
                        + $"Singleton intance:{_singletonService2.GetOperationId()}\n");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
