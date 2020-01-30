using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Data.Model;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketProject.Api.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var newProduct = _productService.CreateApi(product);

            return CreatedAtRoute("GetProduct", new
            {
                id = newProduct.Id
            }, newProduct);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public Product Get(int id)
        {
            return _productService.Get(id);
        }
    }
}