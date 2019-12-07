using FoodDataCentral.Models;
using System.IO;
using System.Net.Http;
using Xunit;

namespace FoodDataCentral.Tests
{
    public class FoodDataCentralAPITests
    {
        [Fact]
        public async void GetFoodById_ValidId_ReturnsFoodObject()
        {
            string sampleJson = File.ReadAllText("Data/BigMacFood.json");
            var mockClient = new HttpClient(Util.MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);
            var api = new FoodDataCentralAPI("DEMO_KEY", webRequester);

            Food food = await api.GetFoodById(170720);
            string description = food.Description;

            Assert.Equal("McDONALD'S, BIG MAC", description);
        }
    }
}
