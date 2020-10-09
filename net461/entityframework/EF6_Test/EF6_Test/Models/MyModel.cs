using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF6Example.Models
{
    public class MyModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Thing> Things { get; set; }
    }
}
