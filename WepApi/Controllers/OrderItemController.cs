using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Data;
using WepApi.Dtos;
using WepApi.Models;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/orderItem
        [HttpGet]
        public ActionResult<IEnumerable<OrderItem>> GetAllOrderItems()
        {
            var orderItemItems = _repository.GetAllOrderItems();
            return Ok(_mapper.Map<IEnumerable<OrderItemReadDto>>(orderItemItems));
        }


        // POST api/orderItem
        [HttpPost]
        public ActionResult<OrderItemReadDto> CreateOrderItem(OrderItemCreateDto orderItemCreateDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemCreateDto);

            //TO-DO validate the data
            _repository.CreateOrderItem(orderItem);
            _repository.SaveChanges();

            //pass back to dto
            var orderItemReadDto = _mapper.Map<OrderItemReadDto>(orderItem);

            return Ok(orderItemReadDto);
        }

    }
}
