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
            return Ok(_saleService.GetSales());
        }

        [HttpGet("GetSales/{id}")]
        public ActionResult<Venta> GetSaleById(int id)
        {
            return Ok(_saleService.GetSaleById(id));
        }

        [HttpPost("PostSale")]
        public ActionResult<Venta> PostSale([FromBody] Venta venta)
        {
            return Ok(_saleService.PostSale(venta));
        }

        [HttpPut("PutSale/{id}")]
        public ActionResult<Venta> PutSale(int id, [FromBody] Venta venta)
        {
            return Ok(_saleService.PutSale(id, venta));
        }

        [HttpDelete("DeleteSale/{id}")]
        public ActionResult<Venta> DeleteSale(int id)
        {
            return Ok(_saleService.DeleteSale(id));
        }
    }
}
