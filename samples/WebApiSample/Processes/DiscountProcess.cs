using FlowNet.Processes;
using WebApiSample.Processes.Contexts;

namespace WebApiSample.Processes
{
    public class DiscountProcess : Process<SaleContext>
    {
        public override SaleContext Execute(SaleContext input)
        {
            var taxPercentage = 0.25m;

            var tax = (input.Value - input.Discount) * taxPercentage;

            input.Discounts.Add(new SaleDiscount
            {
                Name = "Coupom discount",
                Value = tax
            });

            return input;
        }
    }
}
