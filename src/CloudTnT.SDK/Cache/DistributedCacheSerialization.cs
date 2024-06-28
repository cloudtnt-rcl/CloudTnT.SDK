#nullable disable

using System.Text.Json;

namespace CloudTnT.SDK
{
    public static class DistributedCacheSerialization
    {
        public static string ToJsonString(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            string json = JsonSerializer.Serialize(obj);
            return json;
        }
        public static T FromJsonString<T>(this string jsonString) where T : class
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }
            T obj = JsonSerializer.Deserialize<T>(jsonString);
            return obj;
        }
    }
}
