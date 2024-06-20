using Microsoft.Extensions.DependencyInjection;

namespace CloudTnT.SDK
{
    public static class ApiExtensions
    {
        public static IServiceCollection ConfigureCloudTnTApiOptions(this IServiceCollection services,
           Action<ApiOptions> configureOptions)
        {
            services.Configure<ApiOptions>(configureOptions);
            return services;
        }
    }
}
