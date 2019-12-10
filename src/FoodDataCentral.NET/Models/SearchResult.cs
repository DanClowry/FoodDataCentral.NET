using System;

namespace FoodDataCentral.Models
{
    public class SearchResult
    {
        public SearchCriteria FoodSearchCriteria { get; set; }
        public int TotalHits { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public SearchResultFood[] Foods { get; set; }
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
