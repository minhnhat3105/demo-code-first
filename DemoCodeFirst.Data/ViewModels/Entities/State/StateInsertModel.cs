using System.Text.Json.Serialization;

namespace DemoCodeFirst.Data.ViewModels.Entities.State
{
    public class StateInsertModel
    {
        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
