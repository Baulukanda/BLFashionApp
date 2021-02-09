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
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CustomerController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            var customerItems = _repository.GetAllCustomers();
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customerItems));
        }

        // GET api/customer/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerReadDto> GetCustomer(int id)
        {
            var customerItem = _repository.GetCustomerById(id);
            if (customerItem != null)
            {
                return Ok(_mapper.Map<CustomerReadDto>(customerItem));
            }
            return NotFound();
        }

        // POST api/customer
        [HttpPost]
        public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            var customer = _mapper.Map<Customer>(customerCreateDto);

            //TO-DO validate the data
            _repository.CreateCustomer(customer);
            _repository.SaveChanges();

            //pass back to dto
            var customerReadDto = _mapper.Map<CustomerReadDto>(customer);

            return Ok(customerReadDto);
        }

        // PUT api/customer/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerUpdateDto customerUpdateDto)
        {
            // checking if its correct product
            var customerFromRepo = _repository.GetCustomerById(id);
            if (customerFromRepo == null)
            {
                NotFound();
            }
            _mapper.Map(customerUpdateDto, customerFromRepo);
            _repository.UpdateCustomer(customerFromRepo);

            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/customer/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerFromRepo = _repository.GetProductById(id);
            if (customerFromRepo == null)
            {
                NotFound();
            }
            _repository.DeleteProduct(customerFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
