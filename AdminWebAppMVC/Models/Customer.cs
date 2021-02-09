using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebAppMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }
        
        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
