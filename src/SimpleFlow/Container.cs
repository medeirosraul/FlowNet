using SimpleFlow.Nodes;
using System.Collections.Generic;

namespace SimpleFlow
{
    public class Container
    {
        private readonly List<INode> _nodes = new List<INode>();

        #region Properties

        public IReadOnlyList<INode> Nodes => _nodes;

        #endregion

        #region Methods

        public void AddNode(INode node)
        {
            _nodes.Add(node);
        }

        #endregion
    }
}
