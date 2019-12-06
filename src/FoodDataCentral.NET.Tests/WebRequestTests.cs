using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;
using FoodDataCentral;
using Xunit.Abstractions;
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
            var mockClient = new HttpClient(MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            string returnedString = await webRequester.GetRawAsync("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY");

            Assert.Equal(sampleJson, returnedString);
        }

        [Fact]
        public async void GetAsync_MockFoodEndpoint_ReturnsFoodObject()
        {
            string sampleJson = File.ReadAllText("Data/BigMacFood.json");
            var mockClient = new HttpClient(MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            var returnedObject = await webRequester.GetAsync<Food>("https://api.nal.usda.gov/fdc/v1/170720?api_key=DEMO_KEY");
            string description = returnedObject.description;

            Assert.Equal("McDONALD'S, BIG MAC", description);
        }

        [Fact]
        public async void PostRawAsync_MockSearchEndpoint_ReturnsJsonString()
        {
            string sampleJson = File.ReadAllText("Data/BigMacSearch.json");
            var mockClient = new HttpClient(MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            string returnedString = await webRequester.PostRawAsync("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", "{\"generalSearchInput\": \"big mac\"}");

            Assert.Equal(sampleJson, returnedString);
        }

        // TODO: Replace dynamic with search result model
        [Fact]
        public async void PostAsync_MockSearchEndpoint_ReturnsDynamicSearchResultObject()
        {
            string sampleJson = File.ReadAllText("Data/BigMacSearch.json");
            var mockClient = new HttpClient(MockHttpMessageHandlerFactory("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", sampleJson));
            IRequester webRequester = new WebRequester(mockClient);

            var returnedObject = await webRequester.PostAsync<dynamic>("https://api.nal.usda.gov/fdc/v1/search?api_key=DEMO_KEY", "{\"generalSearchInput\": \"big mac\"}");
            string searchInput = returnedObject.foodSearchCriteria.generalSearchInput;

            Assert.Equal("big mac", searchInput);
        }

        /// <summary>
        /// Creates a mock HttpMessageHandler to be used in a HttpClient
        /// </summary>
        /// <param name="requestUri">The URI to match incoming requests with</param>
        /// <param name="returnValue">The value returned to the HttpClient</param>
        /// <returns>A HttpMessageHandler object</returns>
        /// <example><code>var handler = MockHttpMessageHandlerFactory("https://example.com", "Return this string")</code></example>
        private HttpMessageHandler MockHttpMessageHandlerFactory(string requestUri, string returnValue)
        {
            var messageHandler = new Mock<HttpMessageHandler>();

            messageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == new Uri(requestUri)), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(returnValue) }).Verifiable();

            return messageHandler.Object;
        }
    }
}
