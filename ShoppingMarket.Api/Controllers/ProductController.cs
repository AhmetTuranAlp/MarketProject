using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingMarket.DTO.Entities;
using ShoppingMarket.Service.Base;

namespace ShoppingMarket.Api.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: product
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return _productService.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            product.Id = 0;
            product.ProductId = "";
            var newProduct = _productService.CreateApi(product);

            return CreatedAtRoute("GetProduct", new
            {
                id = newProduct.Result.Id
            }, newProduct);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            var result = _productService.Get(id);
            if (result.Result == null)
            {
                return NotFound();
            }
            return Ok(result.Result);
        }
    }
}