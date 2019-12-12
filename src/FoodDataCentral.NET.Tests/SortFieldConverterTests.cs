using FoodDataCentral.Models;
using Newtonsoft.Json;
using Xunit;

namespace FoodDataCentral.Tests
{
    public class SortFieldConverterTests
    {
        [Theory]
        [InlineData(SortField.LowercaseDescription, "lowercaseDescription.keyword")]
        [InlineData(SortField.DataType, "dataType.keyword")]
        [InlineData(SortField.PublishedDate, "publishedDate")]
        [InlineData(SortField.FdcId, "fdcId")]
        public void SerialiseSearchCriteria_SortFieldNotNull_ReturnsSortFieldJson(SortField sortField, string expectedValue)
        {
            SearchCriteria searchCriteria = new SearchCriteria(null, sortBy: sortField);

            string json = JsonConvert.SerializeObject(searchCriteria, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore } );

            Assert.Contains($"\"sortField\":\"{expectedValue}\"", json);
        }

        [Fact]
        public void SerialiseSearchCriteria_SortFieldNull_DoesNotReturnSortFieldJson()
        {
            SearchCriteria searchCriteria = new SearchCriteria(null, sortBy: null);

            string json = JsonConvert.SerializeObject(searchCriteria, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            Assert.DoesNotContain("\"sortField\":\"lowercaseDescription.keyword\"", json);
        }

        [Theory]
        [InlineData(SortField.LowercaseDescription, "lowercaseDescription.keyword")]
        [InlineData(SortField.DataType, "dataType.keyword")]
        [InlineData(SortField.PublishedDate, "publishedDate")]
        [InlineData(SortField.FdcId, "fdcId")]
        public void DeserialiseSearchResultJson_SortFieldNotNull_ReturnsSortFieldEnum(SortField expectedValue, string sortFieldJson)
        {
            string sampleJson = $"{{\"foodSearchCriteria\":{{\"sortField\":\"{sortFieldJson}\"}}}}";

            SearchResult searchResult = JsonConvert.DeserializeObject<SearchResult>(sampleJson);

            Assert.Equal(expectedValue, searchResult.FoodSearchCriteria.SortField);
        }

        [Fact]
        public void DeserialiseSearchResultJson_SortFieldNull_DoesNotReturnSortFieldEnum()
        {
            string sampleJson = "{\"foodSearchCriteria\":{}}";

            SearchResult searchResult = JsonConvert.DeserializeObject<SearchResult>(sampleJson);

            Assert.Null(searchResult.FoodSearchCriteria.SortField);
        }
    }
}
