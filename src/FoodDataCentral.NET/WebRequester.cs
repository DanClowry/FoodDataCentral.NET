using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodDataCentral
{
    internal class WebRequester : IRequester
    {
        private readonly HttpClient client;

        public WebRequester() : this(new HttpClient()) { }

        public WebRequester(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<string> GetRawAsync(string url)
        {
            return await client.GetStringAsync(url);
        }

        public Task<T> GetAsync<T>(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<string> PostRawAsync(string url, string body)
        {
            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        public Task<T> PostAsync<T>(string url, string body)
        {
            throw new NotImplementedException();
        }
    }
}
