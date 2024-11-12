using System;
using System.Threading.Tasks;

namespace SimpleFlow.Processes
{
    public abstract class Process : IProcess
    {
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}