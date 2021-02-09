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
    public class ShipperController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ShipperController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/shipper
        [HttpGet]
        public ActionResult<IEnumerable<Shipper>> GetAllShippers()
        {
            var shipperItems = _repository.GetAllShippers();
            return Ok(_mapper.Map<IEnumerable<ShipperReadDto>>(shipperItems));
        }

        // GET api/shipper/{id}
        [HttpGet("{id}")]
        public ActionResult<ShipperReadDto> GetShipper(int id)
        {
            var shipperItem = _repository.GetShipperById(id);
            if (shipperItem != null)
            {
                return Ok(_mapper.Map<ShipperReadDto>(shipperItem));
            }
            return NotFound();
        }

        // POST api/shipper
        [HttpPost]
        public ActionResult<ShipperReadDto> CreateShipper(ShipperCreateDto shipperCreateDto)
        {
            var shipper = _mapper.Map<Shipper>(shipperCreateDto);

            //TO-DO validate the data
            _repository.CreateShipper(shipper);
            _repository.SaveChanges();

            //pass back to dto
            var shipperReadDto = _mapper.Map<ShipperReadDto>(shipper);

            return Ok(shipperReadDto);
        }

        // PUT api/shipper/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateShipper(int id, ShipperUpdateDto shipperUpdateDto)
        {
            // checking if its correct product
            var shipperFromRepo = _repository.GetShipperById(id);
            if (shipperFromRepo == null)
            {
                NotFound();
            }
            _mapper.Map(shipperUpdateDto, shipperFromRepo);
            _repository.UpdateShipper(shipperFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/shipper/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteShipper(int id)
        {
            var shipperFromRepo = _repository.GetShipperById(id);
            if (shipperFromRepo == null)
            {
                NotFound();
            }
            _repository.DeleteShipper(shipperFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
