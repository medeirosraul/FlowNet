using SimpleFlow.Processes;

namespace WebApiSample.Transactions
{
    public class ReceiveTransactionProcess : Process
    {
        public Input<string> TransactionId { get; set; } = null!;
        public IOutput<string?> IdOutput { get; set; } = new Output<string?>();

        public override void Execute()
        {
            Console.WriteLine($"Receiving transaction {TransactionId.Value}.");

            IdOutput.Send(TransactionId.Value);
        }
    }
}
