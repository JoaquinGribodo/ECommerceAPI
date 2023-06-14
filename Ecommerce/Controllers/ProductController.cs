using Data.Models;
using Data.Models.ViewModel;
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
            var response = _productService.GetProducts();
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetProducts/{id}")]
        public ActionResult<Producto> GetProductById(int id)
        {
            var response = _productService.GetProductById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("PostProduct")]
        public ActionResult<Producto> PostProduct([FromBody] ProductViewModel producto)
        {
            var response = _productService.PostProduct(producto);
            if (response == null)
            {
                return BadRequest();  //BadRequest porque el recurso no se agregó correctamente
            }
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}"; //Devolver la ubicación con la cual se accede al recurso creado
            string apiAndEndPointUrl = $"api/Product/GetProducts";
            string locationUrl = $"{baseUrl}/{apiAndEndPointUrl} / {response.Id}";
            return Created(locationUrl, response); //El primer parámetro es el header y el segundo parámetro es el body
        }

        [HttpPut("PutProduct/{id}")]
        public ActionResult<Producto> PutProduct(int id, [FromBody] ProductViewModel producto)
        {
            var response = _productService.PutProduct(id, producto);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult<Producto> DeleteProduct(int id)
        {
            var response = _productService.DeleteProduct(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
