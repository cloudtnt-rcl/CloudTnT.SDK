namespace CloudTnT.SDK
{
    public static class NetworkingHelpers
    {
        public async static Task<bool> IsWebsiteValidAsync(string url)
        {
            bool b = false;

            using (var client = new HttpClient())
            {
                try
                {
                    var getResultSSL = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get,url));

                    if (getResultSSL.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("ssl connection"))
                    {
                        return true;
                    }

                    b = false;
                }
            }

            return b;
        }
    }
}
