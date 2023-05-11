using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWise.Models
{
    public class testClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
