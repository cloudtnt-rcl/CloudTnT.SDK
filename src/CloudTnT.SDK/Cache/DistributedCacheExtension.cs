#nullable disable

using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace CloudTnT.SDK
{
    public static class DistributedCacheExtension
    {
        public async static Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DistributedCacheEntryOptions options, CancellationToken token = default(CancellationToken))
        {
            await distributedCache.SetAsync(key, Encoding.ASCII.GetBytes(value.ToJsonString()), options, token);
        }

        public async static Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default(CancellationToken)) where T : class
        {
            byte[] resultBytes = await distributedCache.GetAsync(key, token);
            string result = Encoding.ASCII.GetString(resultBytes);
            return result.FromJsonString<T>();
        }
    }
}
