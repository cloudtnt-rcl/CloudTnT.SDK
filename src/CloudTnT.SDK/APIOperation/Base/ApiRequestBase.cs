# nullable disable

using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace CloudTnT.SDK
{
    internal abstract class ApiRequestBase
    {
        protected static readonly HttpClient _client;
        private readonly IOptions<ApiOptions> _apiOptions;
      
        static ApiRequestBase()
        {
            _client = new HttpClient();
        }

        protected ApiRequestBase(IOptions<ApiOptions> apiOptions)
        {
            _apiOptions = apiOptions;
        }

        public async Task PostAsync<T>(string endpoint, T payload)
            where T : class
        {
            try
            {
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiOptions.Value.ApiKey);

                var response = await _client.PostAsync($"{_apiOptions.Value.ApiBaseUrl}/{endpoint}/subscription/{_apiOptions.Value.SubscriptionId}",
                     new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception($"ERROR from {this.GetType().Name} : {response.StatusCode} : {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"ERROR from {this.GetType().Name} : {ex.Message}");
            }
        }

        public async Task<TResult> PostAsync<T, TResult>(string endpoint, T payload)
            where TResult : new()
            where T : class
        {
            try
            {
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiOptions.Value.ApiKey);

                var response = await _client.PostAsync($"{_apiOptions.Value.ApiBaseUrl}/{endpoint}/subscription/{_apiOptions.Value.SubscriptionId}",
                     new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    TResult obj = JsonSerializer.Deserialize<TResult>(content);
                    return obj;
                }
                else
                {
                    throw new Exception($"ERROR from {this.GetType().Name} : {response.StatusCode} : {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(string endpoint)
        {
            try
            {
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiOptions.Value.ApiKey);

                var response = await _client.DeleteAsync($"{_apiOptions.Value.ApiBaseUrl}/{endpoint}/subscription/{_apiOptions.Value.SubscriptionId}");

                string content = ResolveContent(await response.Content.ReadAsStringAsync());

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"ERROR from {this.GetType().Name} : {response.StatusCode} : {content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ResolveContent(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }
            else
            {
                if (content.ToLower().Contains("!doctype html"))
                {
                    return string.Empty;
                }
                else
                {
                    return content;
                }
            }
        }

    }
}
