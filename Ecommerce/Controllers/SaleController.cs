using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private SaleService _saleService;

        private SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpGet("GetSales")]
        public ActionResult<List<Venta>> GetSales()
        {
            var response = _saleService.GetSales();
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetSales/{id}")]
        public ActionResult<Venta> GetSaleById(int id)
        {
            var response = _saleService.GetSaleById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("PostSale")]
        public ActionResult<Venta> PostSale([FromBody] Venta venta)
        {
            var response = _saleService.PostSale(venta);
            if (response == null)
            {
                return BadRequest();  
            }
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}"; 
            string apiAndEndPointUrl = $"api/Sale/GetSales";
            string locationUrl = $"{baseUrl}/{apiAndEndPointUrl} / {response.Id}";
            return Created(locationUrl, response);
        }

        [HttpPut("PutSale/{id}")]
        public ActionResult<Venta> PutSale(int id, [FromBody] Venta venta)
        {
            var response = _saleService.PutSale(id, venta);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("DeleteSale/{id}")]
        public ActionResult<Venta> DeleteSale(int id)
        {
            var response = _saleService.DeleteSale(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
