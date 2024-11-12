using SimpleFlow.Processes;
using System.Threading.Tasks;

namespace SimpleFlow.Nodes
{
    public interface INode<TProcess>
        where TProcess : IProcess
    {
        string Identifier { get; }
        string Name { get; }
        void Activate(TProcess process);
        void Execute();
        Task ExecuteAsync();
    }
}
