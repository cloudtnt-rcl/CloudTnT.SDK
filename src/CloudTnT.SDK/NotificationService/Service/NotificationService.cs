using Microsoft.Extensions.Options;

namespace CloudTnT.SDK
{
    internal class NotificationService : ApiRequestBase, INotificationService
    {
        private readonly IOptions<ApiOptions> _apiOptions;

        public NotificationService(IOptions<ApiOptions> apiOptions)
            : base(apiOptions)
        {
            _apiOptions = apiOptions;
        }

        public async Task<List<NotificationEntity>> GetNotificationsByUsernameAsync(NotificationEntity notification)
        {
            try
            {
                List<NotificationEntity> notifications = await PostAsync<NotificationEntity, List<NotificationEntity>>("notification/get", notification);
                return notifications;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateNotificationAsync(NotificationEntity notification)
        {
            try
            {
                await PostAsync<NotificationEntity>("notification/create", notification);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteNotificationAsync(NotificationEntity notification)
        {
            try
            {
                await PostAsync<NotificationEntity>("notification/delete", notification);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
