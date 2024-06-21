using Microsoft.Extensions.Options;

namespace CloudTnT.SDK
{
    internal class DIDService : ApiRequestBase, IDIDService
    {
        private readonly IOptions<ApiOptions> _apiOptions;

        public DIDService(IOptions<ApiOptions> apiOptions)
            :base(apiOptions)
        {
            _apiOptions = apiOptions;
        }

        public async Task<DIDEntity> CreateDIDWebAsync(DIDEntity did)
        {
            DIDEntity _did = new DIDEntity();

            try
            {
                _did = await PostAsync<DIDEntity, DIDEntity>("did/create/didweb", did);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _did;
        }

        public async Task<DIDEntity> SaveDIDWebAsync(DIDEntity did)
        {
            DIDEntity _did = new DIDEntity();

            try
            {
                _did = await PostAsync<DIDEntity, DIDEntity>("did/save/didweb", did);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _did;
        }

        public async Task<DIDEntity> CreateAndSaveDIDJwkAsync(DIDEntity did)
        {
            DIDEntity _did = new DIDEntity();

            try
            {
                _did = await PostAsync<DIDEntity, DIDEntity>("did/createsave/didjwk", did);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _did;
        }

        public async Task<List<DIDEntity>> GetDIDAsync(string filter, DIDEntity did)
        {
            List<DIDEntity> _dids = new List<DIDEntity>();

            try
            {
                _dids = await PostAsync<DIDEntity, List<DIDEntity>>($"did/get/{filter}", did);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _dids;
        }

        public async Task DeleteDIDAsync(DIDEntity did)
        {
            try
            {
                await PostAsync("did/delete", did);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
