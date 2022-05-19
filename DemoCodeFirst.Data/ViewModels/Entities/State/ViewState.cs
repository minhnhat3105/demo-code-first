using System.Text.Json.Serialization;

namespace DemoCodeFirst.Data.ViewModels.Entities.State
{
    public class ViewState
    {
        public int Id { get; set; }
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }
        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }
        public string Name { get; set; }
    }
}
