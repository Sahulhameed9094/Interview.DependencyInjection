using Interview.DependencyInjection.Controllers;
using Interview.DependencyInjection.InterfacesDI;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interview.DependencyInjection.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Values1Controller : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransientService _transientService;
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;


        public Values1Controller(ILogger<HomeController> logger,
                                 IScopedService scopedService,
                                 ITransientService transientService,
                                 ISingletonService singletonService)
        {
            _logger = logger;
            _scopedService = scopedService;
            _transientService = transientService;
            _singletonService = singletonService;
        }
        [HttpGet]
        public string Get()
        {
            //_logger.LogInformation(_transientService.GetOperationId().ToString());
            return $"Transient intance:{_transientService.GetOperationId()}\n"
                        + $"Scoped intance:{_scopedService.GetOperationId()}\n"
                        + $"Singleton intance:{_singletonService.GetOperationId()}\n";

        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
