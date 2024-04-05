using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

            return services;
        }
    }
}
