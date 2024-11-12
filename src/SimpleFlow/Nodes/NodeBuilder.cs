using SimpleFlow.Processes;
using System;

namespace SimpleFlow.Nodes
{
    public class NodeBuilder<TProcess>
        where TProcess : IProcess
    {
        private readonly Flow _flow;
        public Node<TProcess> Node { get; set; }

        public NodeBuilder(Flow flow, Node<TProcess> node)
        {
            _flow = flow;
            Node = node;
        }

        public static NodeBuilder<TProcess> Create(Flow flow, string? identifier = null, string? name = null)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                identifier = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(name))
                name = identifier;

            return new NodeBuilder<TProcess>(flow, new Node<TProcess>(identifier, name));
        }
    }
}
