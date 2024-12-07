using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Employye
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
