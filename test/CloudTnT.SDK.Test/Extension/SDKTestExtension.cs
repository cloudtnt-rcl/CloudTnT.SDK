using Microsoft.Extensions.DependencyInjection;

namespace CloudTnT.SDK.Test
{
    public static class SDKTestExtension
    {
        public static IServiceCollection ConfigureCloudTnTSDKTestOptions(this IServiceCollection services,
            Action<SDKTestOptions> setupAction)
        {
            services.Configure<SDKTestOptions>(setupAction);

            return services;
        }
    }
}
