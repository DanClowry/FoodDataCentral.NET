using System.Net.Http;
using Xunit;
using System.IO;
using FoodDataCentral.Models;

namespace FoodDataCentral.Tests
{
    public class WebRequestTests
    {
        [Fact]
        public async void GetRawAsync_MockFoodEndpoint_ReturnsJsonString()
        {
            string sampleJson = File.ReadAllText("Data/BigMacFood.json");
            var mockClient = new HttpClient(Util.MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            string returnedString = await webRequester.GetRawAsync("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY");

            Assert.Equal(sampleJson, returnedString);
        }

        [Fact]
        public async void GetAsync_MockFoodEndpoint_ReturnsFoodObject()
        {
            string sampleJson = File.ReadAllText("Data/BigMacFood.json");
            var mockClient = new HttpClient(Util.MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            var returnedObject = await webRequester.GetAsync<Food>("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY");
            string description = returnedObject.Description;

            Assert.Equal("McDONALD'S, BIG MAC", description);
        }

        [Fact]
        public async void PostRawAsync_MockSearchEndpoint_ReturnsJsonString()
        {
            string sampleJson = File.ReadAllText("Data/BigMacSearch.json");
            var mockClient = new HttpClient(Util.MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            string returnedString = await webRequester.PostRawAsync("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", "{\"generalSearchInput\": \"big mac\"}");

            Assert.Equal(sampleJson, returnedString);
        }

        [Fact]
        public async void PostAsync_MockSearchEndpoint_ReturnsSearchResultObject()
        {
            string sampleJson = File.ReadAllText("Data/BigMacSearch.json");
            var mockClient = new HttpClient(Util.MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            var returnedObject = await webRequester.PostAsync<SearchResult>("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", "{\"generalSearchInput\": \"big mac\"}");
            string searchInput = returnedObject.FoodSearchCriteria.GeneralSearchInput;

            Assert.Equal("big mac", searchInput);
        }
    }
}
