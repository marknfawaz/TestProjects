using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsFull.Models
{
    public class People
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public People(string name, string lastname, string position)
        {
            Name = name;
            LastName = lastname;
            Position = position;
        }
    }
}