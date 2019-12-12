using FoodDataCentral.Models.Converters;
using Newtonsoft.Json;

namespace FoodDataCentral.Models
{
    public class SearchCriteria
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
        [JsonConverter(typeof(SortFieldConverter))]
        public SortField? SortField { get; set; }
        [JsonProperty("sortDirection")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortDirection? SortDirection { get; set; }
        [JsonProperty("requireAllWords")]
        public bool RequireAllWords { get; set; }
    }

    public class IncludeDataTypes
    {
        [JsonProperty("SR Legacy")]
        public bool SRLegacy { get; set; }
        [JsonProperty("Survey (FNDDS)")]
        public bool SurveyFNDDS { get; set; }
        public bool Foundation { get; set; }
        public bool Branded { get; set; }
    }

    public enum SortField
    {
        LowercaseDescription,
        DataType,
        PublishedDate,
        FdcId
    }

    public enum SortDirection
    {
        asc,
        desc
    }
}
