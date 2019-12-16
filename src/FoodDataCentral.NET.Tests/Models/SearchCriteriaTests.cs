using FoodDataCentral.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FoodDataCentral.Tests.Models
{
    public class SearchCriteriaTests
    {
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings(){ NullValueHandling = NullValueHandling.Ignore };

        [Fact]
        public void SerialiseObject_SearchTerm_ReturnsGeneralSearchTermJson()
        {
            var search = new SearchCriteria("Example query");

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"generalSearchInput\":\"Example query\"", json);
        }

        [Fact]
        public void SerialiseObject_IncludeDataTypes_ReturnsIncludeDataTypesObjectJson()
        {
            var search = new SearchCriteria(null, includeLegacy: false, includeSurvey: false,
                includeFoundation: false, includeBranded: false);

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"includeDataTypes\":{\"SR Legacy\":false," +
                "\"Survey (FNDDS)\":false,\"Foundation\":false,\"Branded\":false}"
                , json);
        }

        [Fact]
        public void SerialiseObject_BrandOwner_ReturnsBrandOwnerJson()
        {
            var search = new SearchCriteria(null, brandOwner: "Example company");

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"brandOwner\":\"Example company\"", json);
        }

        [Fact]
        public void SerialiseObject_Ingredients_ReturnsIngredientsJson()
        {
            var search = new SearchCriteria(null, ingredients: "Sugar");

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"ingredients\":\"Sugar\"", json);
        }

        [Fact]
        public void SerialiseObject_PageNumber_ReturnsPageNumberJson()
        {
            var search = new SearchCriteria(null, pageNumber: 15);

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"pageNumber\":15", json);
        }

        [Fact]
        public void SerialiseObject_SortField_ReturnsSortFieldJson()
        {
            var search = new SearchCriteria(null, sortBy: SortField.LowercaseDescription);

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"sortField\":\"lowercaseDescription.keyword\"", json);
        }

        [Fact]
        public void SerialiseObject_SortDirection_ReturnsSortDirectionJson()
        {
            var search = new SearchCriteria(null, sortDirection: SortDirection.asc);

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"sortDirection\":\"asc\"", json);
        }

        [Fact]
        public void SerialiseObject_RequireAllWords_ReturnsRequireAllWordsJson()
        {
            var search = new SearchCriteria(null, requireAllWords: true);

            string json = JsonConvert.SerializeObject(search, settings);

            Assert.Contains("\"requireAllWords\":true", json);
        }
    }
}
