namespace CloudTnT.SDK
{
    public interface INotificationService
    {
        public Task<List<NotificationEntity>> GetNotificationsByUsernameAsync(NotificationEntity notification);
        Task CreateNotificationAsync(NotificationEntity notification);
        public Task DeleteNotificationAsync(NotificationEntity notification);
    }
}
