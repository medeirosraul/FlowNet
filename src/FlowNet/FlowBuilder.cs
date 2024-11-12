using FlowNet.Nodes;

namespace FlowNet
{
    public class FlowBuilder
    {
        private readonly Flow _flow;

        public FlowBuilder(Flow flow)
        {
            _flow = flow;
        }

        /// <summary>
        /// Add a node in the root of the flow.
        /// </summary>
        /// <typeparam name="TProcess"></typeparam>
        /// <returns></returns>
        public NodeBuilder<TInput, TOutput> AddNode<TInput, TOutput>(string? identifier = null, string? name = null)
        {
            var nodeBuilder = NodeBuilder<TInput, TOutput>.Create(_flow, identifier, name);

            _flow.AddRootNode(nodeBuilder.Node);

            return nodeBuilder;
        }

        /// <summary>
        /// Add a node in the root of the flow with the same input and output type.
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="identifier"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public NodeBuilder<TInput, TInput> AddNode<TInput>(string? identifier = null, string? name = null)
        {
            return AddNode<TInput, TInput>(identifier, name);
        }
    }
}
