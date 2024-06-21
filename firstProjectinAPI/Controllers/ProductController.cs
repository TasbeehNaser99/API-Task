using firstProjectinAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstProjectinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product>Products=new List<Product>() { 
            new Product(){Id=1,Name="Car",Description="This is Car"},
             new Product(){Id=2,Name="Laptop",Description="This is Laptop"},
              new Product(){Id=3,Name="Phone",Description="This is Phone"},
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = Products.Find(p=>p.Id==id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Add(Product response)
        {
            if(response is null)
            {
                return BadRequest();
            }
            var product= new Product
            {
                Id=response.Id,
                Name=response.Name,
                Description=response.Description,
            };
            Products.Add(product);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,Product response)
        {
            var currentProduct= Products.FirstOrDefault(p=>p.Id == id);
            if (currentProduct == null)
            {
                return NotFound();
            }
            currentProduct.Name = response.Name;
            currentProduct.Description = response.Description;

            return Ok(currentProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product=Products.FirstOrDefault(p=>p.Id==id);
            if (product == null)
            {
                return NotFound();
            }
            Products.Remove(product);
            return Ok();
        }
    }
}
