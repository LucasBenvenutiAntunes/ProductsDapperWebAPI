using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAllProducts();
        }

        [HttpGet("{PageId}")]
        public IEnumerable<Product> Get(int PageId)
        {
            return productRepository.GetAllProductsByPage(PageId);
        }

        [HttpGet("id/{id}")]
        public Product GetById (int id)
        {
            return productRepository.GetProductsById(id);
        }

        [HttpPost]
        public void Post([FromBody]Product prod)
        {
            if (ModelState.IsValid)
                productRepository.Add(prod);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product prod)
        {
            prod.ProductId = id;
            if (ModelState.IsValid)
                productRepository.UpdateProduct(prod);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            productRepository.DeleteProduct(id);
        }

    }
}