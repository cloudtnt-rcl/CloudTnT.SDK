using Microsoft.Extensions.DependencyInjection;

namespace CloudTnT.SDK.Test
{
    public static class NotificationTestExtension
    {
        public static IServiceCollection ConfigureCloudTnTNotificationTestOptions(this IServiceCollection services,
            Action<NotificationTestOptions> setupAction)
        {
            services.Configure<NotificationTestOptions>(setupAction);

            return services;
        }
    }
}
