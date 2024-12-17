using Interview.DependencyInjection.Controllers;
using Interview.DependencyInjection.InterfacesDI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interview.DependencyInjection.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
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



        private readonly ILogger<ValuesController> _logger;


        public ValuesController(
            ITransientService transientService,
            ISingletonService singletonService,
            IScopedService scopedService,
            ITransientService transientService2,
            ISingletonService singletonService2,
            IScopedService scopedService2)
        {
            _transientService = transientService;
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService2 = transientService2;
            _singletonService2 = singletonService2;
            _scopedService2 = scopedService2;
        }


        // GET: api/<ValuesController1>
        [HttpGet]
        public string Get()
        {
            //_logger.LogInformation(_transientService.GetOperationId().ToString());
            return $"Transient intance:{_transientService.GetOperationId()}\n"
                        + $"Transient intance:{_transientService2.GetOperationId()}\n"
                        + $"Scoped intance:{_scopedService.GetOperationId()}\n"
                        + $"Scoped intance:{_scopedService2.GetOperationId()}\n"
                        + $"Singleton intance:{_singletonService.GetOperationId()}\n"
                        + $"Singleton intance:{_singletonService2.GetOperationId()}\n";

        }
        // GET: api/<ValuesController1>
        [HttpGet]
        [Route("GetDATA")]
        public string GetDATA()
        {

            return $"Transient intance:{_transientService.GetOperationId()}\n"
                        + $"Scoped intance:{_scopedService.GetOperationId()}\n"
                        + $"Singleton intance:{_singletonService.GetOperationId()}\n";

        }
    }
}
