using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly _productService = new ProductService();
        [HttpGet("GetList")]
        public ActionResult<List<Product>> GetListadoProductos()
        {
            var response = _productService.ListarProductos();
            return Ok(response);
        }

        [HttpGet("GetList/{id}")]
        public ActionResult<Product> GetProductoPorId(int id)
        {
            var response = _productService.ListarProductosPorId(id);
            return Ok(response);
        }

        [HttpPost("PostProduct")]
        public ActionResult<Product> PostProducto([FromBody] Product product)
        {
            var response = _productService.AgregarProducto(product);
            return Ok(response);
        }

        [HttpPut("PutProduct/{id}")]
        public ActionResult<Product> PutProducto(int id, [FromBody] Product product)
        {
            var response = _productService.ActualizarProducto(id, product);
            return Ok(response);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult<Product> PutProducto(int id)
        {
            var response = _productService.EliminarProducto(id);
            return Ok(response);
        }
    }
}
