using FlowNet.Nodes;
using FlowNet.Processes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FlowNet
{
    public class Flow
    {
        private string _identifier;
        private string _name;
        private readonly FlowOptions _options;
        private readonly IServiceProvider _serviceProvider;
        
        public List<INode> RootNodes { get; } = [];

        private List<INode> Nodes { get; } = [];
        
        public string Name => _name;

        public Flow(IOptionsSnapshot<FlowOptions> options, IServiceProvider serviceProvider, string identifier)
        {
            _options = options.Get(identifier);
            _serviceProvider = serviceProvider;

            _identifier = identifier;
            _name = _options.Name;

            _options.Build(this);
        }

        #region Node API

        public void AddNode(INode node)
        {
            Nodes.Add(node);
        }

        public void AddRootNode(INode node)
        {
            RootNodes.Add(node);
        }

        #endregion

        #region Process API
        public IProcess<TInput, TOutput> GetProcess<TInput, TOutput>(Type processType)
        {
            return (IProcess<TInput, TOutput>)_serviceProvider.GetRequiredService(processType);
        }
        #endregion
    }
}