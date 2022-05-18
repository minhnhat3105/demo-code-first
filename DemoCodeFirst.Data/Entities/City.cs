using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCodeFirst.Data.Entities
{
    [Table("City")]
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        
        public State State { get; set; }
    }
}
