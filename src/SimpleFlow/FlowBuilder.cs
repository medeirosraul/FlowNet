namespace SimpleFlow
{
    public class FlowBuilder
    {
        private readonly Flow _flow;

        public FlowBuilder(Flow flow)
        {
            _flow = flow;
        }

        #region Access

        public Flow Flow => _flow;

        #endregion

        #region Building

        public static FlowBuilder Create()
        {
            return new FlowBuilder(new Flow());
        }

        #endregion
    }
}
