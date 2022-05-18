using System.Text.Json.Serialization;

namespace DemoCodeFirst.Data.ViewModels.Common
{
    public class PagingResult<T> where T : class
    {
        [JsonPropertyName("total_page")]
        public int TotalPage { get; set; }
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }
        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        [JsonPropertyName("has_next")]
        public bool HasNext { get; set; }
        [JsonPropertyName("has_prev")]
        public bool HasPrev { get; set; }

        public PagingResult(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            int size = items.Count;
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = (size < pageSize) ? size : pageSize;
            // calculating
            TotalPage = (int) Math.Ceiling(totalCount / (double) pageSize);
            HasNext = (TotalPage > PageNumber) ? true : false;
            HasPrev = (PageNumber > 1) ? true : false;
        }

    }
}
