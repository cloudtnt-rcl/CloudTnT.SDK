#nullable disable

using Microsoft.Extensions.Options;

namespace CloudTnT.SDK.Test
{
    [TestClass]
    public class NotificationServiceTest
    {
        private readonly INotificationService _service;
        private readonly IOptions<ApiOptions> _apiOptions;
        private readonly IOptions<NotificationTestOptions> _testOptions;

        public NotificationServiceTest()
        {
            _service = (INotificationService)DependencyResolver.ServiceProvider().GetService(typeof(INotificationService));
            _apiOptions = (IOptions<ApiOptions>)DependencyResolver.ServiceProvider().GetService(typeof(IOptions<ApiOptions>));
            _testOptions = (IOptions<NotificationTestOptions>)DependencyResolver.ServiceProvider().GetService(typeof(IOptions<NotificationTestOptions>));
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

                await _service.CreateNotificationAsync(notificationEntity);

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

                List<NotificationEntity> Notifications = await _service.GetNotificationsByUsernameAsync(notificationEntity);

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

                await _service.DeleteNotificationAsync(notificationEntity);

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
