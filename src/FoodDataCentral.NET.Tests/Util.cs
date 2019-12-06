using Moq;
using Moq.Protected;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FoodDataCentral.Tests
{
    internal static class Util
    {
        /// <summary>
        /// Creates a mock HttpMessageHandler to be used in a HttpClient
        /// </summary>
        /// <param name="requestUri">The URI to match incoming requests with</param>
        /// <param name="returnValue">The value returned to the HttpClient</param>
        /// <returns>A HttpMessageHandler object</returns>
        /// <example><code>var handler = MockHttpMessageHandlerFactory("https://example.com", "Return this string")</code></example>
        internal static HttpMessageHandler MockHttpMessageHandlerFactory(string requestUri, string returnValue)
        {
            var messageHandler = new Mock<HttpMessageHandler>();

            messageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == new Uri(requestUri)), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(returnValue) }).Verifiable();

            return messageHandler.Object;
        }
    }
}
