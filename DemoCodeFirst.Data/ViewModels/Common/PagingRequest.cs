using Microsoft.AspNetCore.Mvc;

namespace DemoCodeFirst.Data.ViewModels.Common
{
    public class PagingRequest
    {
        // default value
        private const int MAX_PAGE_SIZE = 50;
        private int _pageSize = 10;

        [FromQuery(Name = "pageNumber")]
        public int PageNumber { get; set; } = 1;
        [FromQuery(Name = "pageSize")]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
            }
        } 
    }
}
