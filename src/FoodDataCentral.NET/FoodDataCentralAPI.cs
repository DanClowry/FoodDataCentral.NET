using FoodDataCentral.Controllers;
using FoodDataCentral.Models;
using System.Threading.Tasks;

namespace FoodDataCentral
{
    public class FoodDataCentralAPI
    {
        private readonly IRequester requester;
        private readonly FoodController foodController;
        private readonly SearchController searchController;

        public FoodDataCentralAPI(string apiKey) : this(apiKey, new WebRequester()) { }

        public FoodDataCentralAPI(string apiKey, IRequester requester)
        {
            this.requester = requester;
            foodController = new FoodController(requester, apiKey);
            searchController = new SearchController(requester, apiKey);
        }

        public async Task<Food> GetFoodById(int id)
        {
            return await foodController.GetFoodById(id);
        }

        public async Task<SearchResult> Search(string searchTerm, bool includeLegacy = true, 
            bool includeSurvey = true, bool includeFoundation = true, bool includeBranded = true,
            string ingredients = null, string brandOwner = null, bool requireAllWords = false, 
            int pageNumber = 1, SortField? sortBy = null, SortDirection? sortDirection = null)
        {
            var search = new SearchCriteria(searchTerm, includeLegacy, includeSurvey,
            includeFoundation, includeBranded, ingredients, brandOwner, requireAllWords, pageNumber,
            sortBy, sortDirection);
            return await searchController.Search(search);
        }
    }
}
