using DemoCodeFirst.Data.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DemoCodeFirst.Data.RequestModel
{
    public class StateRequestModel : PagingRequest
    {
        [FromQuery(Name = "id")]
        public int? Id { get; set; }
        [FromQuery(Name = "countryId")]
        public int? CountryId { get; set; }
        [FromQuery(Name = "name")]
        public string? Name { get; set; }
        [FromQuery(Name = "status")]
        public bool? Status { get; set; }
    }
}
