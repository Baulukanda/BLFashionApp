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
    public class OrdersController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public OrdersController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/orders
        [HttpGet]
        public ActionResult<IEnumerable<Orders>> GetAllOrders()
        {
            var orderItems = _repository.GetAllOrders();
            return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orderItems));
        }

        // GET api/orders/{id}
        [HttpGet("{id}")]
        public ActionResult<OrderReadDto> GetOrder(int id)
        {
            var orderItem = _repository.GetOrderById(id);
            if (orderItem != null)
            {
                return Ok(_mapper.Map<OrderReadDto>(orderItem));
            }
            return NotFound();
        }

        // POST api/orders
        [HttpPost]
        public ActionResult<OrderReadDto> CreateOrder(OrderCreateDto ordersCreateDto)
        {
            var order = _mapper.Map<Orders>(ordersCreateDto);

            //TO-DO validate the data
            _repository.CreateOrder(order);
            _repository.SaveChanges();

            //pass back to dto
            var ordersReadDto = _mapper.Map<OrderReadDto>(order);

            return Ok(ordersReadDto);
        }

        // PUT api/Orders/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, OrderUpdateDto ordersUpdateDto)
        {
            // checking if its correct order
            var orderFromRepo = _repository.GetOrderById(id);
            if (orderFromRepo == null)
            {
                NotFound();
            }
            _mapper.Map(ordersUpdateDto, orderFromRepo);
            _repository.UpdateOrder(orderFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/order/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var orderFromRepo = _repository.GetOrderById(id);
            if (orderFromRepo == null)
            {
                NotFound();
            }
            _repository.DeleteOrder(orderFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
