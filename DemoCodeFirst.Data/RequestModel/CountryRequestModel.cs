using DemoCodeFirst.Data.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DemoCodeFirst.Data.RequestModel
{
    public class CountryRequestModel : PagingRequest
    {
        [FromQuery(Name = "id")]
        public int? Id { get; set; }
        [FromQuery(Name = "name")]
        public string? Name { get; set; }
        [FromQuery(Name = "status")]
        public bool? Status { get; set; }
    }
}
