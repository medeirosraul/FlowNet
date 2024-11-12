using Microsoft.Extensions.DependencyInjection;
using SimpleFlow.Processes;
using System;
using System.Threading.Tasks;

namespace SimpleFlow.Nodes
{
    public class Node<TProcess> : INode
        where TProcess : IProcess
    {
        private readonly string _identifier;
        private readonly string _name;
        private TProcess _process;

        public string Identifier => _identifier;

        public string Name => _name;

        public Type ProcessType => typeof(TProcess);

        public Node(string identifier, string name)
        {
            _identifier = identifier;
            _name = name;
        }

        public void Activate(IServiceProvider serviceProvider)
        {
            _process = serviceProvider.GetRequiredService<TProcess>();
        }

        public void Execute()
        {
            _process.Execute();
        }

        public Task ExecuteAsync()
        {
            return _process.ExecuteAsync();
        }
    }
}
