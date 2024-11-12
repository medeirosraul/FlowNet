using SimpleFlow.Processes;

namespace WebApiSample.Transactions
{
    public class ReceiveTransactionProcess : Process
    {
        public Input<string> TransactionId { get; set; } = null!;

        public override void Execute()
        {
            Console.WriteLine($"Receiving transaction {TransactionId.Value}.");
        }
    }
}
