using FlowNet.Processes;

namespace FlowNet.Nodes
{
    public class NodeBuilder<TInput, TOutput>
    {
        private readonly Flow _flow;

        public Node<TInput, TOutput> Node;

        public NodeBuilder(Flow flow, Node<TInput, TOutput> node)
        {
            _flow = flow;
            Node = node;
        }

        public static NodeBuilder<TInput, TOutput> Create(Flow flow, string? identifier = null, string? name = null)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                identifier = Guid.NewGuid().ToString();

            var node = new Node<TInput, TOutput>(identifier, name ?? identifier);

            return new NodeBuilder<TInput, TOutput>(flow, node);
        }

        public NodeBuilder<TOutput, TNextOutput> AddNext<TNextOutput>(string? identifier = null, string? name = null)
        {
            var builder = NodeBuilder<TOutput, TNextOutput>.Create(_flow, identifier, null)
                .AddPrevious(Node);

            AddNext(builder.Node);

            return builder;
        }

        #region Flow

        public NodeBuilder<TInput, TOutput> AddPrevious(INode node)
        {
            Node.Previous.Add(node);

            return this;
        }

        public NodeBuilder<TInput, TOutput> AddNext(INode node)
        {
            Node.Next.Add(node);

            return this;
        }

        #endregion

        #region Process

        public NodeBuilder<TInput, TOutput> WithProcess<TProcess>()
            where TProcess : IProcess<TInput, TOutput>
        {
            Node.ProcessType = typeof(TProcess);

            return this;
        }

        #endregion
    }
}
