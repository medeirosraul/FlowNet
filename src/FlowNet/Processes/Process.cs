namespace FlowNet.Processes
{
    public abstract class Process<TInput> : Process<TInput, TInput>
    {

    }

    public abstract class Process<TInput, TOutput> : IProcess<TInput, TOutput>
    {
        public virtual TOutput Execute(TInput input)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TOutput> ExecuteAsync(TInput input)
        {
            return Task.FromResult(Execute(input));
        }
    }
}
