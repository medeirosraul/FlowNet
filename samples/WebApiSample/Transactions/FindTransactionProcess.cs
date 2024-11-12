using SimpleFlow.Processes;

namespace WebApiSample.Transactions
{
    public class FindTransactionProcess : Process
    {
        public IInput<string?> TransactionId { get; set; } = null!;

        public override void Execute()
        {
            if (TransactionId.Value == null)
            {
                return;
            }

            Console.WriteLine($"Finding transaction {TransactionId.Value}.");
        }
    }
}
