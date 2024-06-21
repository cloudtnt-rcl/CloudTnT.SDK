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
        public async Task GetDIDTest()
        {
            try
            {
                DIDEntity didEntityRequest = new DIDEntity
                {
                    userName = _testOptions.Value.username,
                    idToken = _testOptions.Value.idtoken
                };

                List<DIDEntity> didEntities = await _didService.GetDIDAsync("username", didEntityRequest);

                Assert.AreNotEqual(0,didEntities.Count);

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
                    did = "did:jwk:eyJraWQiOiI2OTY2OWM0ZTI4YmM0ZWQ5Iiwia3R5IjoiUlNBIiwiZSI6IkFRQUIiLCJuIjoib1BpK09CUE4wN3Q5TWU1MzBYU3FzUW5LUnJucCtQNk5Wa2JqdzBJT0p0K0dYYkl6VHFpakp1U0lVYS9raG83L0xva2JtSmphR2IwVDJYYzFVZTJUMEs4WHVPekpwN3AweGtqM094NXArYUZWSUl6T0RhK05zQUc5QWxOZUdqeHVKRmFFdlVGUE8rRU4rcnVwMEFJRndSRkxpam85MFNVZjZHUGEwMUdIbXNpb0U0bGJtRHZlUkdhajE1dzlEcHZQYVl4UlhhRy9SV295dFg2REFScURSbm02WWZtZ3FiTTBkSDg3eENWMEdmdEU1Z2FsN1BhWmFvblpra01xUnJwd3lnSVdmMkdCU2thVkV6S2N5TTdIZnprZTYwbm5TdTlBWncwWkxKM0FhLzg0YnozT05FK01tRmF5VWNoVW1IZFg1aEFkYXRRUjhUWTh4LzN0bkpnWVRRPT0ifQ"
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
    }
}
