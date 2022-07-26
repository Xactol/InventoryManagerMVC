using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public partial class Employee
    {
        
        public string? Name { get; set; }
    
        public string? Surname { get; set; }
        
        public string? City { get; set; }

        public string Email { get; set; } = null!;


        public override string ToString()
        {
            return Name + " " + Surname + " " + City + " " + Email;
        }
    }
}
