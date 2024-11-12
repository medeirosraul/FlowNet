using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FlowNet
{
    public static class FlowExtensions
    {
        public static IServiceCollection AddFlow(this IServiceCollection services, string name, Action<FlowOptions> configure)
        {
            // Add Flow as a keyed service into the DI container
            services.AddKeyedScoped(name, (sp, name) =>
            {
                return new Flow(sp.GetRequiredService<IOptionsSnapshot<FlowOptions>>(), sp, (string)name!);
            });

            // Configure the FlowOptions<TContext> with the provided configuration
            services.Configure(name, configure);

            return services;
        }
    }
}
