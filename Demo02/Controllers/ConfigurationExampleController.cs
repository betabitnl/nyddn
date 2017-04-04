using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Demo02.Configuration;

namespace Demo02.Controllers
{
    [Route("api/[controller]")]
    public class ConfigurationExampleController : Controller
    {
        //TODO: 4.2 Configuration options used in controller
        private readonly ComplexConfiguration _configuration;

        public ConfigurationExampleController(IOptions<ComplexConfiguration> optionsAccessor)
        {
            _configuration = optionsAccessor.Value;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _configuration.Key4;
        }
    }
}
