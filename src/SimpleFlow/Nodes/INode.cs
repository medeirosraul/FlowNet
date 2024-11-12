using SimpleFlow.Processes;
using System.Threading.Tasks;

namespace SimpleFlow.Nodes
{
    public interface INode
    {
        string Identifier { get; }
        string Name { get; }
        void Execute();
        Task ExecuteAsync();
    }
}
