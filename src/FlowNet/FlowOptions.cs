namespace FlowNet
{
    public class FlowOptions
    {
        public string Name { get; set; }

        Action<FlowBuilder>? Builder { get; set; }

        public void CreateBuilder(Action<FlowBuilder> builder)
        {
            Builder = builder;
        }

        public void Build(Flow flow)
        {
            FlowBuilder builder = new FlowBuilder(flow);
            
            Builder?.Invoke(builder);
        }
    }
}
