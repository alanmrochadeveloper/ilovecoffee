using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ilovecoffee.Models;

namespace ilovecoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductMockList ProdList{get;set;}
        public ProductsController(ProductMockList mList)
        {
            ProdList = mList;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return ProdList.AllProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(long id)
        {
            Product product = ProdList.FindOne(id);
            if(product != null){
                return product;
            }
            return NotFound();;
        }

        [HttpPost("")]
        public ActionResult<Product> PostProduct(Product model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(long id, Product model)
        {
            if(model.Id == id){
                if(model.Id > 0){
                    ProdList.Update(model);
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProductById(long id)
        {
            ProdList.Delete(id);
            return null;
        }
    }
}