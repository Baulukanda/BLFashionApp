using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApi.Dtos
{
    public class ShipperCreateDto
    {
        public string Name { get; set; }
    }

    public class ShipperReadDto
    {
        public string Name { get; set; }
    }

    public class ShipperUpdateDto
    {
        public string Name { get; set; }
    }
}
