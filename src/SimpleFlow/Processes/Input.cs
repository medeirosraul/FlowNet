using System;

namespace SimpleFlow.Processes
{
    public class Input<TValue> : IInput<TValue>
    {
        private TValue _value = default!;

        public TValue Value => _value;

        public void SetValue(TValue value)
        {
            _value = value;
        }
    }
}
