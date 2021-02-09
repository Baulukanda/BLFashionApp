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
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/product
        [HttpGet]
        public ActionResult <IEnumerable<Product>> GetAllProducts()
        {
            var productItems = _repository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
        }

        // GET api/Product/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetProduct(int id)
        {
            var productItem = _repository.GetProductById(id);
            if (productItem != null)
            {
                return Ok(_mapper.Map<ProductReadDto>(productItem));
            }
            return NotFound();
        }

        // POST api/product
        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);

            //TO-DO validate the data
            _repository.CreateProduct(product);
            _repository.SaveChanges();

            //pass back to dto
            var productReadDto = _mapper.Map<ProductReadDto>(product);

            return Ok(productReadDto);
        }

        // PUT api/product/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            // checking if its correct product
            var productFromRepo = _repository.GetProductById(id);
            if(productFromRepo == null)
            {
                NotFound();
            }
            _mapper.Map(productUpdateDto, productFromRepo);
            _repository.UpdateProduct(productFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/product/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var productFromRepo = _repository.GetProductById(id);
            if (productFromRepo == null)
            {
                NotFound();
            }
            _repository.DeleteProduct(productFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
