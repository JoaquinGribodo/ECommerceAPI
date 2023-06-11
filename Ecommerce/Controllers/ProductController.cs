using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;

        private ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProducts")]
        public ActionResult<List<Producto>> GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("GetProducts/{id}")]
        public ActionResult<Producto> GetProductById(int id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpPost("PostProduct")]
        public ActionResult<Producto> PostProduct([FromBody] Producto producto)
        {
            return Ok(_productService.PostProduct(producto));
        }

        [HttpPut("PutProduct/{id}")]
        public ActionResult<Producto> PutProduct(int id, [FromBody] Producto producto)
        {
            return Ok(_productService.PutProduct(id, producto));
        }

        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult<Producto> DeleteProduct(int id)
        {
            return Ok(_productService.DeleteProduct(id));
        }
    }
}
