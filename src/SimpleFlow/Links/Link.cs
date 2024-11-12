using SimpleFlow.Processes;
using System;
using System.Linq.Expressions;

namespace SimpleFlow.Links
{
    public class Link<TProcess, TValue> : ILink<TValue>
            where TProcess : IProcess
    {
        private TProcess _process;
        private Expression<Func<TProcess, IInput<TValue>>> _expression;
        private Action<TProcess, IInput<TValue>> _setter;
        private Func<TProcess, IInput<TValue>> _getter;

        public void SetExpression(Expression<Func<TProcess, IInput<TValue>>> expression)
        {
            _expression = expression;
        }

        public void Activate(TProcess process)
        {
            _process = process;
            CompileGetter();
            CompileSetter();

            var input = new Input<TValue>();
            _setter(_process, input);
        }

        public void CompileGetter()
        {
            _getter = _expression.Compile();
        }

        public void CompileSetter()
        {
            var memberExpression = (MemberExpression)_expression.Body;
            var target = Expression.Parameter(typeof(TProcess));
            var value = Expression.Parameter(typeof(IInput<TValue>));

            var newMemberExpression = Expression.MakeMemberAccess(target, memberExpression.Member);
            var assign = Expression.Assign(newMemberExpression, value);

            _setter = Expression.Lambda<Action<TProcess, IInput<TValue>>>(assign, target, value).Compile();
        }

        public void Transmit(TValue data)
        {
            var input = _getter(_process);
            input.SetValue(data);

            _process.Execute();
        }
    }
}
