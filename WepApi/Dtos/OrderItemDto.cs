using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;

namespace WepApi.Dtos
{
    public class OrderItemCreateDto
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class OrderItemReadDto
    {
        public Orders OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class OrderItemUpdateDto
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
