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

        private SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpGet("GetSales")]
        public ActionResult<List<SaleDTO>> GetSales()
        {
            var response = _saleService.GetSales();
            if (response.Count == 0)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("GetSales/{id}")]
        public ActionResult<SaleDTO> GetSaleById(int id)
        {
            var response = _saleService.GetSaleById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("PostSale")]
        public ActionResult<SaleDTO> PostSale([FromBody] SaleViewModel venta)
        {
            var response = _saleService.PostSale(venta);
            if (response == null)
            {
                return BadRequest();  
            }
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}"; 
            string apiAndEndPointUrl = $"api/Product/GetProducts";
            string locationUrl = $"{baseUrl}/{apiAndEndPointUrl} / {response.Id}";
            return Created(locationUrl, response); 
        }

        [HttpPut("PutSale/{id}")]
        public ActionResult PutSale(int id, [FromBody] SaleViewModel venta)
        {
            _saleService.PutSale(id, venta);
            return Ok();
        }

        [HttpDelete("DeleteSale/{id}")]
        public ActionResult<SaleDTO> DeleteSale(int id)
        {
            _saleService.DeleteSale(id);
            return Ok();
        }
    }
}
