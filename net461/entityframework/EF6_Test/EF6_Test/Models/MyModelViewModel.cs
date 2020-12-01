using System.ComponentModel.DataAnnotations;

namespace EF6Example.Models
{
    public class MyModelViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
