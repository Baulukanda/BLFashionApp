using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Dtos
{
    public class OrderCreateDto
    {

        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
        public OrderStatus status { get; set; }
    }

    public class OrderReadDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
        public OrderStatus status { get; set; }
    }

    public class OrderUpdateDto
    {

        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
        public OrderStatus status { get; set; }
    }
}
