using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodDataCentral
{
    class WebRequester : IRequester
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

        public async Task<T> GetAsync<T>(string url)
        {
            string response = await GetRawAsync(url);
            return JsonConvert.DeserializeObject<T>(response);
        }

        public async Task<string> PostRawAsync(string url, string body)
        {
            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<T> PostAsync<T>(string url, string body)
        {
            var response = await PostRawAsync(url, body);
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
