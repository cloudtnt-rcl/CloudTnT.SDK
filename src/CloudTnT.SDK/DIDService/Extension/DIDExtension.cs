using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CloudTnT.SDK
{
    public static class DIDExtension
    {
        public static IServiceCollection AddCloudTnTDIDServices(this IServiceCollection services)
        {
            services.TryAddTransient<IDIDService, DIDService>();

            return services;
        }
    }
}
