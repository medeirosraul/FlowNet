using FlowNet.Processes;
using System.Diagnostics.CodeAnalysis;

namespace FlowNet.Nodes
{
    public class Node<TInput, TOutput> : INode
    {
        private readonly string _identifier;
        private readonly string _name;

        private readonly Flow _flow;

        private IProcess<TInput, TOutput>? _process;

        public Type ProcessType;

        public IList<INode> Previous { get; } = [];

        public IList<INode> Next { get; } = [];

        public string Identifier => _identifier;

        public string Name => _name;

        public Node(string identifier, string name)
        {
            _identifier = identifier;
            _name = name;
        }

        public void Execute(object input)
        {
            ValidateProcess(_process);
            ValidateInput(input);

            var output = _process.Execute((TInput)input);
        }

        public async Task ExecuteAsync(object input)
        {
            ValidateProcess(_process);
            ValidateInput(input);

            var output = await _process.ExecuteAsync((TInput)input);
        }

        private void ValidateProcess([NotNull] IProcess<TInput, TOutput>? _process)
        {
            if (_process == null)
                throw new InvalidOperationException("Node has not been initialized.");
        }

        private void ValidateInput(object input)
        {
            if (!(input is TInput))
                throw new InvalidOperationException("Input type does not match the expected input type.");
        }
    }
}