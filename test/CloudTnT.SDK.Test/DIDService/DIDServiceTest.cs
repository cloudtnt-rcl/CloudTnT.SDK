#nullable disable

using Microsoft.Extensions.Options;

namespace CloudTnT.SDK.Test
{
    [TestClass]
    public class DIDServiceTest
    {
        private readonly IOptions<ApiOptions> _apiOptions;
        private readonly IOptions<SDKTestOptions> _testOptions;
        private readonly IDIDService _didService;

        public DIDServiceTest()
        {
            _apiOptions = (IOptions<ApiOptions>)DependencyResolver.ServiceProvider().GetService(typeof(IOptions<ApiOptions>));
            _testOptions = (IOptions<SDKTestOptions>)DependencyResolver.ServiceProvider().GetService(typeof(IOptions<SDKTestOptions>));
            _didService = (IDIDService)DependencyResolver.ServiceProvider().GetService(typeof(IDIDService));
        }

        [TestMethod]
        public async Task CreateAndSaveDIDJwkTest()
        {
            try
            {
                DIDEntity didEntityRequest = new DIDEntity
                {
                    userName = _testOptions.Value.username,
                    uuid = _testOptions.Value.uuid,
                    idToken = _testOptions.Value.idtoken
                };

                DIDEntity newDIDEntity = await _didService.CreateAndSaveDIDJwkAsync(didEntityRequest);

                Assert.AreEqual(didEntityRequest.userName, newDIDEntity.userName);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CreateDIDWebTest()
        {
            try
            {
                DIDEntity newDIDEntity = await CreateDIDWebAsync();

                Assert.AreEqual(_testOptions.Value.username, newDIDEntity.userName);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task SaveDIDWebTest()
        {
            try
            {
                DIDEntity newDIDEntity = await CreateDIDWebAsync();

                DIDEntity savedDIDEntity = await _didService.SaveDIDWebAsync(newDIDEntity);

                Assert.AreEqual(_testOptions.Value.username, savedDIDEntity.userName);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetDIDByUsernameTest()
        {
            try
            {
                DIDEntity didEntityRequest = new DIDEntity
                {
                    userName = _testOptions.Value.username,
                    idToken = _testOptions.Value.idtoken
                };

                List<DIDEntity> didEntities = await _didService.GetDIDAsync("username", didEntityRequest);

                Assert.AreNotEqual(0, didEntities.Count);

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetDIDByDIDTest()
        {
            try
            {
                DIDEntity didEntityRequest = new DIDEntity
                {
                    did = "did:web:cloudtnt.com",
                    idToken = _testOptions.Value.idtoken
                };

                List<DIDEntity> didEntities = await _didService.GetDIDAsync("did", didEntityRequest);

                Assert.AreNotEqual(0, didEntities.Count);

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task DeleteDIDTest()
        {
            try
            {
                DIDEntity didEntityRequest = new DIDEntity
                {
                    idToken = _testOptions.Value.idtoken,
                    did = "did:web:cloudtnt.com"
                };

                await _didService.DeleteDIDAsync(didEntityRequest);

                Assert.AreEqual(1, 1);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }

        private async Task<DIDEntity> CreateDIDWebAsync()
        {
            try
            {
                DIDEntity didEntityRequest = new DIDEntity
                {
                    userName = _testOptions.Value.username,
                    uuid = _testOptions.Value.uuid,
                    idToken = _testOptions.Value.idtoken,
                    did = "did:web:cloudtnt.com"
                };

                DIDEntity newDIDEntity = await _didService.CreateDIDWebAsync(didEntityRequest);

                return newDIDEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
