namespace CloudTnT.SDK
{
    public interface IDIDService
    {
        public Task<DIDEntity> CreateDIDWebAsync(DIDEntity did);
        public Task<DIDEntity> SaveDIDWebAsync(DIDEntity did);
        public Task<DIDEntity> CreateAndSaveDIDJwkAsync(DIDEntity did);
        public Task<List<DIDEntity>> GetDIDAsync(string filter, DIDEntity did);
        public Task DeleteDIDAsync(DIDEntity did);
    }
}
