using System.Text.Json.Serialization;

namespace DemoCodeFirst.Data.ViewModels.Entities.State
{
    public class StateUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }    
    }
}
