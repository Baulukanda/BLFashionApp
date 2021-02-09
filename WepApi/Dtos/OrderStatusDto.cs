using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Dtos
{
    public class OrderStatusCreateDto
    {
        public string Name { get; set; }
    }

    public class OrderStatusReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderStatusUpdateDto
    {
        public string Name { get; set; }
    }
}
