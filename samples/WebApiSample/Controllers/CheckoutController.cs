using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(ILogger<CheckoutController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public void Get()
        {
            return;
        }
    }
}
