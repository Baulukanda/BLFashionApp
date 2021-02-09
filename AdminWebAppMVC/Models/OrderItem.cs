using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebAppMVC.Models
{
    [Keyless]
    public class OrderItem
    {
        public Orders Order { get; set; }
        public Product Product { get; set; }
        
        [Required]
        public int Quantity { get; set; }
       
        [Required]
        public int UnitPrice { get; set; }
    }
}
