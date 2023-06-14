using Data.Models;
using Data.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SaleRepository
    {
        private readonly ECommerceDBContext _dbContext;
        public SaleRepository(ECommerceDBContext eCommerceDBContext)
        {
            _dbContext = eCommerceDBContext;
        }
        public List<Venta> GetSales()
        {
            return _dbContext.Venta.ToList();
        }

        public Venta GetSaleById(int id)
        {
            Venta venta = Sales.Where(x => x.IdVenta == id).FirstOrDefault();

            return venta;
        }
        public Venta PostSale(SaleViewModel venta)
        {
            Venta venta1 = new Venta()
            {
                IdProducto = venta.IdProducto,
                IdUsuario = venta.IdUsuario,
                FechaVenta = venta.FechaVenta,
                MontoTotal = venta.MontoTotal,

            };
            _dbContext.Venta.Add(venta1);
            _dbContext.SaveChanges();

            return venta1;
        }
        public List<Venta> PutSale(int id, Venta venta)
        {
            var ventaAModificar = Sales.Where(x => x.Id == id).First();
            ventaAModificar.Id = venta.Id;
            ventaAModificar.IdProducto = venta.IdProducto;
            ventaAModificar.IdUsuario = venta.IdUsuario;
            ventaAModificar.FechaVenta = venta.FechaVenta;
            ventaAModificar.MontoTotal = venta.MontoTotal;

            return Sales;
        }
        public void DeleteSale(int id)
        {
            Venta venta = Sales.Where(w => w.Id == id).First();
            Sales.Remove(venta);
        }
    }
}
