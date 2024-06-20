using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CloudTnT.SDK
{
    public static class NotificationExtension
    {
        public static IServiceCollection AddCloudTnTNotificationConnectorServices(this IServiceCollection services)
        {
            services.TryAddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}
