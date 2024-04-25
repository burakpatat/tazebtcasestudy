using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Shared.Application.Mediator
{
    public static class ServiceRegistiration
    {
        public static void AddMediatRService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
