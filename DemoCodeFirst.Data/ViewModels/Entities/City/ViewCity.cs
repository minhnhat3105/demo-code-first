using System.Text.Json.Serialization;

namespace DemoCodeFirst.Data.ViewModels.Entities.City
{
    public class ViewCity
    {
        public int Id { get; set; }
        [JsonPropertyName("state_id")]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Name { get; set; }
    }
}
