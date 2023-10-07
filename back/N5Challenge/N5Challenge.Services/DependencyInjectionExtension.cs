using Microsoft.Extensions.DependencyInjection;

namespace N5Challenge.Services
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjectionExtension).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}