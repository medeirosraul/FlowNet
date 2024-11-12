using SimpleFlow.Links;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleFlow.Processes
{
    public class Output<TValue> : IOutput<TValue>
    {
        private readonly List<ILink<TValue>> _links = new List<ILink<TValue>>();

        public void Connect<TProcess, TInput>(Expression<Func<TProcess, TInput>> expression)
            where TInput : IInput<TValue>
        {

        }

        public void Send(TValue value)
        {
            foreach (var link in _links)
            {
                link.Transmit(value);
            }
        }
    }
}
