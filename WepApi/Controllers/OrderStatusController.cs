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
    public class OrderStatusController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public OrderStatusController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/orderStatus
        [HttpGet]
        public ActionResult<IEnumerable<OrderStatus>> GetAllOrderStatuses()
        {
            var statusItems = _repository.GetAllOrderStatuses();
            return Ok(_mapper.Map<IEnumerable<OrderStatusReadDto>>(statusItems));
        }

        // GET api/OrderStatus/{id}
        [HttpGet("{id}")]
        public ActionResult<OrderStatusReadDto> GetOrderStatus(int id)
        {
            var statusItem = _repository.GetOrderStatusById(id);
            if (statusItem != null)
            {
                return Ok(_mapper.Map<OrderStatusReadDto>(statusItem));
            }
            return NotFound();
        }

        // POST api/OrderStatus
        [HttpPost]
        public ActionResult<OrderStatusReadDto> CreateOrderStatus(OrderStatusCreateDto orderStatusCreateDto)
        {
            var orderStatus = _mapper.Map<OrderStatus>(orderStatusCreateDto);

            //TO-DO validate the data
            _repository.CreateOrderStatus(orderStatus);
            _repository.SaveChanges();

            //pass back to dto
            var orderStatusReadDto = _mapper.Map<OrderStatusReadDto>(orderStatus);

            return Ok(orderStatusReadDto);
        }

        // PUT api/orderStatus/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateOrderStatus(int id, OrderStatusUpdateDto orderStatusUpdateDto)
        {
            // checking if its correct orderStatus
            var orderStatusFromRepo = _repository.GetOrderStatusById(id);
            if (orderStatusFromRepo == null)
            {
                NotFound();
            }
            _mapper.Map(orderStatusUpdateDto, orderStatusFromRepo);
            _repository.UpdateOrderStatus(orderStatusFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/OrderStatus/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrderStatus(int id)
        {
            var orderStatusFromRepo = _repository.GetOrderStatusById(id);
            if (orderStatusFromRepo == null)
            {
                NotFound();
            }
            _repository.DeleteOrderStatus(orderStatusFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
