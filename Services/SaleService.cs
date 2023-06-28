using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
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

        public SaleDTO GetSaleById(int id)
        {
            return _saleRepository.GetSaleById(id);
        }

        public List<SaleDTO> GetSales()
        {
            return _saleRepository.GetSales();
        }

        public SaleDTO PutSale(SaleViewModel venta) 
        { 
            return _saleRepository.PutSale(venta);
        }

        public SaleDTO PostSale(SaleViewModel venta)
        {
            return _saleRepository.PostSale(venta);
        }

        public void DeleteSale(int id)
        {
            _saleRepository.DeleteSale(id);
        }
    }
}
