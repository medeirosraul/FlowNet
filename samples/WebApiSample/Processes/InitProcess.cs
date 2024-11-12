using FlowNet.Processes;
using WebApiSample.Processes.Contexts;

namespace WebApiSample.Processes
{
    public class InitProcess : IProcess<SaleContext>
    {
        public SaleContext Execute(SaleContext input)
        {
            throw new NotImplementedException();
        }

        Task<SaleContext> IProcess<SaleContext, SaleContext>.ExecuteAsync(SaleContext input)
        {
            throw new NotImplementedException();
        }
    }
}