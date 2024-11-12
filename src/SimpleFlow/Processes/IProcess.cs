using System.Threading.Tasks;

namespace SimpleFlow.Processes
{
    public interface IProcess
    {
        void Execute();
        Task ExecuteAsync();
    }
}
