using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISaleService
    {
        List<SaleDTO> GetSales();
        SaleDTO GetSaleById(int id);
        SaleDTO PostSale(SaleViewModel venta);
        void PutSale(int id, SaleViewModel venta);
        void DeleteSale(int id);
    }
}