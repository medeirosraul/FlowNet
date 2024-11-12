namespace SimpleFlow.Processes
{
    public interface IOutput<TValue>
    {
        void Send(TValue value);
    }
}
