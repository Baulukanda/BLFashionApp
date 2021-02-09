using AdminWebAppMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminWebAppMVC.Models
{
    public class Orders
    {

        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
        public OrderStatus status { get; set; }

    }
}
