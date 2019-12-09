using FoodDataCentral.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FoodDataCentral.Controllers
{
    internal class SearchController : BaseController
    {
        public SearchController(IRequester requester, string apiKey) : base(requester, apiKey) { }

        public async Task<SearchResult> Search(FoodSearchCriteria search)
        {
            var settings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            string json = JsonConvert.SerializeObject(search, settings);
            SearchResult result = await requester.PostAsync<SearchResult>("https://api.nal.usda.gov/fdc/v1/search?api_key=" + apiKey, json);
            return result;
        }
    }
}
