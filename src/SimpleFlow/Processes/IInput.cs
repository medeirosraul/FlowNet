namespace SimpleFlow.Processes
{
    public interface IInput<T>
    {
        T Value { get; }
        void SetValue(T input);
    }
}
