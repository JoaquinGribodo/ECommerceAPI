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
    public class SaleController : ControllerBase
    {
        private ISaleService _saleService;
        private readonly ILogger<UserController> _logger;


        public SaleController(ISaleService saleService, ILogger<UserController> logger)
        {
            _saleService = saleService;
            _logger = logger;
        }
        [HttpGet("GetSales")]
        public ActionResult<List<SaleDTO>> GetSales()
        {
            try
            {
                var response = _saleService.GetSales();
                if (response.Count == 0)
                {
                    return NotFound("No pudo encontrarse la lista de ventas.");

                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método GetSales: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
            
        }

        [HttpGet("GetSales/{id}")]
        public ActionResult<SaleDTO> GetSaleById(int id)
        {
            try
            {
                var response = _saleService.GetSaleById(id);
                if (response == null)
                {
                    return NotFound("No pudo encontrarse la venta correspondiente a ese Id.");

                }
                return Ok(response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método GetSales/id: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }

        }

        [HttpPost("PostSale")]
        public ActionResult<SaleDTO> PostSale([FromBody] SaleViewModel venta)
        {
            try
            {
                var response = _saleService.PostSale(venta);
                if (response == null)
                {
                    return NotFound("No pudo agregarse la venta.");
                }
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndPointUrl = $"api/Sale/GetSales";
                string locationUrl = $"{baseUrl}/{apiAndEndPointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método GetSales/id: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
        }

        [HttpPut("PutSale")]
        public ActionResult PutSale([FromBody] SaleViewModel venta)
        {
            try
            {
                var response = _saleService.PutSale(venta);
                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndPointUrl = $"api/User/GetSales";
                string locationUrl = $"{baseUrl}/{apiAndEndPointUrl}/{response.Id}";
                return Created(locationUrl, response);
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método PutSale/id: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
        }

        [HttpDelete("DeleteSale/{id}")]
        public ActionResult<SaleDTO> DeleteSale(int id)
        {
            try
            {
                _saleService.DeleteSale(id);
                return Ok();
            }
            catch (Exception exe)
            {
                _logger.LogError($"Ocurrió un error en el método DeleteSale/id: {exe.Message}");
                return BadRequest($"{exe.Message}");
            }
        }
    }
}
