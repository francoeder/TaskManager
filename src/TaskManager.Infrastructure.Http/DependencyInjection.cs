using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Infrastructure.Http.Internal;

namespace TaskManager.Infrastructure.Http
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureHttp(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextProvider>();

            return services;
        }
    }
}
