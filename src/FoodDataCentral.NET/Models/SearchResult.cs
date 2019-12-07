using Newtonsoft.Json;
using System;

namespace FoodDataCentral.Models
{
    public class SearchResult
    {
        public FoodSearchCriteria FoodSearchCriteria { get; set; }
        public int TotalHits { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public SearchResultFood[] Foods { get; set; }
    }

    public class FoodSearchCriteria
    {
        [JsonProperty("includeDataTypes")]
        public IncludeDataTypes IncludeDataTypes { get; set; }
        [JsonProperty("generalSearchInput")]
        public string GeneralSearchInput { get; set; }
        [JsonProperty("brandOwner")]
        public string BrandOwner { get; set; }
        [JsonProperty("ingredients")]
        public string Ingredients { get; set; }
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }
        [JsonProperty("sortField")]
        public string SortField { get; set; }
        [JsonProperty("sortDirection")]
        public string SortDirection { get; set; }
        [JsonProperty("requireAllWords")]
        public bool RequireAllWords { get; set; }
    }

    public class IncludeDataTypes
    {
        public bool SRLegacy { get; set; }
        public bool SurveyFNDDS { get; set; }
        public bool Foundation { get; set; }
        public bool Branded { get; set; }
    }

    public class SearchResultFood
    {
        public int FdcId { get; set; }
        public string Description { get; set; }
        public string AdditionalDescriptions { get; set; }
        public string DataType { get; set; }
        public string FoodCode { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AllHighlightFields { get; set; }
        public float Score { get; set; }
        public string CommonNames { get; set; }
        public string NdbNumber { get; set; }
        public string ScientificName { get; set; }
    }

}
