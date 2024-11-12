namespace FlowNet.Nodes
{
    public interface INode
    {
        string Identifier { get; }

        string Name { get; }

        void Execute(object input);

        Task ExecuteAsync(object input);
    }
}
