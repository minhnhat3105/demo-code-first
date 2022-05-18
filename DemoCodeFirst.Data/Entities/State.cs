using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCodeFirst.Data.Entities
{
    [Table("State")]
    public class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public Country Country { get; set; }
        public List<City> cities { get; set; }
    }
}
