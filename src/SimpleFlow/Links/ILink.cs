namespace SimpleFlow.Links
{
    public interface ILink<TValue>
    {
        void Transmit(TValue data);
    }
}
