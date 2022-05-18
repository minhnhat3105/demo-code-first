using System.Text.Json.Serialization;

namespace DemoCodeFirst.Data.ViewModels.State
{
    public class ViewState
    {
        public int Id { get; set; }
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
