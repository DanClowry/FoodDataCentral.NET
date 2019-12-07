using FoodDataCentral.Models;
using System.Threading.Tasks;

namespace FoodDataCentral.Controllers
{
    internal class FoodController
    {
        private readonly IRequester requester;
        private readonly string apiKey;

        public FoodController(IRequester requester, string apiKey)
        {
            this.requester = requester;
            this.apiKey = apiKey;
        }

        public async Task<Food> GetFoodById(int id)
        {
            return await requester.GetAsync<Food>("https://api.nal.usda.gov/fdc/v1/" + id + "?api_key=" + apiKey);
        }
    }
}
