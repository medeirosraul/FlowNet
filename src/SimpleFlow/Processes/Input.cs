using System;

namespace SimpleFlow.Processes
{
    public class Input<TInput>
            where TInput : class
    {
        private TInput? _value;

        public event EventHandler? ValueChanged;

        public TInput? Value
        {
            get => _value;
            set
            {
                if (!Equals(this._value, value))
                {
                    this._value = value;
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
