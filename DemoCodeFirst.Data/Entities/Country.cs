using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCodeFirst.Data.Entities
{
    [Table("Country")]
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public List<State> States { get; set; } 
    }
}
