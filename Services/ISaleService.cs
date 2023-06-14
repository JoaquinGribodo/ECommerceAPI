using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ISaleService
    {
        List<Venta> GetSales();
        Venta GetSaleById(int id);
        Venta PostSale(Venta venta);
        List<Venta> PutSale(int id, Venta venta);
        void DeleteSale(int id);
    }
}