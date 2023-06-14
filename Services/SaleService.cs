using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleService : ISaleService
    {
        private SaleRepository _saleRepository { get; set; }

        public SaleService(SaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        private SaleService() { }

        public Venta GetSaleById(int id)
        {
            return _saleRepository.GetSaleById(id);
        }

        public List<Venta> GetSales()
        {
            return _saleRepository.GetSales();
        }

        public List<Venta> PutSale(int id, Venta venta)
        {
            return _saleRepository.PutSale(id, venta);
        }

        public Venta PostSale(Venta venta)
        {
            return _saleRepository.PostSale(venta);
        }

        public void DeleteSale(int id)
        {
            _saleRepository.DeleteSale(id);
        }
    }
}
