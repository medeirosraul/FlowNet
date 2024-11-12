using Microsoft.AspNetCore.Mvc;
using SimpleFlow;
using SimpleFlow.Links;
using SimpleFlow.Nodes;
using SimpleFlow.Processes;
using WebApiSample.Transactions;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
        }

        [HttpGet("Get")]
        public void Get()
        {
            var flow = new Flow();
            var node = new Node<ReceiveTransactionProcess>("_init", "Início");

            // Adiciona o primeiro nó
            flow.Container.AddNode(node);
            return;
        }

        [HttpGet("TestOutput")]
        public void TestOutput()
        {
            Output<string?> output = new Output<string?>();

            output.Connect<FindTransactionProcess, IInput<string?>>(x => x.TransactionId);
        }

        [HttpGet("TestLink")]
        public void TestLink()
        {
            var findTransactionProcess = new FindTransactionProcess();
            var link = new Link<FindTransactionProcess, string?>();

            link.SetExpression(x => x.TransactionId);
            link.Activate(findTransactionProcess);

            link.Transmit("123");
        }
    }
}
