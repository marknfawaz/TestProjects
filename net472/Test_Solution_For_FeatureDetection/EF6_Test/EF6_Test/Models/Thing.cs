using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF6Example.Models
{
    public class Thing
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public MyModel AModel { get; set; }
    }
}
