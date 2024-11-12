using System.Data.SqlTypes;

namespace FlowNet.Processes
{
    public interface IProcess<TInputOutput> : IProcess<TInputOutput, TInputOutput>
    {

    }

    public interface IProcess<TInput, TOutput>
    {
        TOutput Execute(TInput input);
        Task<TOutput> ExecuteAsync(TInput input);
    }
}
