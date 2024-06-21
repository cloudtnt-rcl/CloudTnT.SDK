#nullable disable

using Microsoft.Extensions.Options;

namespace CloudTnT.SDK.Test
{
    [TestClass]
    public class NotificationServiceTest
    {
        private readonly IOptions<ApiOptions> _apiOptions;
        private readonly IOptions<SDKTestOptions> _testOptions;
        private readonly INotificationService _notificationService;


        public NotificationServiceTest()
        {
            _apiOptions = (IOptions<ApiOptions>)DependencyResolver.ServiceProvider().GetService(typeof(IOptions<ApiOptions>));
            _testOptions = (IOptions<SDKTestOptions>)DependencyResolver.ServiceProvider().GetService(typeof(IOptions<SDKTestOptions>));
            _notificationService = (INotificationService)DependencyResolver.ServiceProvider().GetService(typeof(INotificationService));
        }

        [TestMethod]
        public async Task CreateNotificationTest()
        {
            try
            {
                NotificationEntity notificationEntity = new NotificationEntity
                {
                    subject = "Test Subject",
                    message = "Test Message",
                    userName = _testOptions.Value.username,
                    uuid = _testOptions.Value.uuid,
                    idToken = _testOptions.Value.idtoken,
                    date = DateTime.Now,
                    type = NotificationConstants.Information
                };

                await _notificationService.CreateNotificationAsync(notificationEntity);

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetNotificationsByUsernameTest()
        {
            try
            {
                NotificationEntity notificationEntity = new NotificationEntity
                {
                    userName = _testOptions.Value.username,
                    idToken = _testOptions.Value.idtoken,
                };

                List<NotificationEntity> Notifications = await _notificationService.GetNotificationsByUsernameAsync(notificationEntity);

                Assert.AreNotEqual(0, Notifications.Count);
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DeleteNotificationTest()
        {
            try
            {
                NotificationEntity notificationEntity = new NotificationEntity
                {
                    id = 11,
                    idToken = _testOptions.Value.idtoken,
                };

                await _notificationService.DeleteNotificationAsync(notificationEntity);

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }
}
