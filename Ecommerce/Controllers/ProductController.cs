using Azure;
using Data.Models;
using Data.Models.DTO;
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
        private IProductService _productService;
        private readonly ILogger<UserController> _logger;

        public ProductController(IProductService productService, ILogger<UserController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet("GetProducts")]
        public ActionResult<List<ProductDTO>> GetProducts()
        {
            try
            {
                var response = _productService.GetProducts();
                if (response.Count == 0)
                {
                    return NotFound("No pudo encontrarse la lista de productos.");
                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método GetProducts: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpGet("GetProducts/{id}")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            try
            {
                var response = _productService.GetProductById(id);
                if (response == null)
                {
                    return NotFound("No pudo encontrarse la lista de productos.");
                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método GetProducts/id: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpPost("PostProduct")]
        public ActionResult<ProductDTO> PostProduct([FromBody] ProductViewModel producto)
        {
            try
            {
                var response = _productService.PostProduct(producto);
                if (response == null)
                {
                    return NotFound("No pudo agregarse el producto.");
                }
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}"; //Devolver la ubicación con la cual se accede al recurso creado
                string apiAndEndPointUrl = $"api/Product/GetProducts";
                string locationUrl = $"{baseUrl}/{apiAndEndPointUrl}/{response.Id}";
                return Created(locationUrl, response); //El primer parámetro es el header y el segundo parámetro es el body
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método PostProduct: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpPut("PutProduct")]
        public ActionResult PutProduct([FromBody] ProductViewModel producto)
        {
            try
            {
                var response = _productService.PutProduct(producto);
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndPointUrl = $"api/Product/GetProducts";
                string locationUrl = $"{baseUrl}/{apiAndEndPointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método PutProduct: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpDelete("DeleteProduct/{id}")]
        public ActionResult<ProductDTO> DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método DeleteProduct: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
        }
    }
}
