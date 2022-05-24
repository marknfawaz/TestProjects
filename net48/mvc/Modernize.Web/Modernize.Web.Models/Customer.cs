using System.ComponentModel.DataAnnotations;

namespace Modernize.Web.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}