using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SaleRepository
    {
        public List<Venta> GetSales()
        {
            return Sales;
        }

        public Venta GetSaleById(int id)
        {
            Venta venta = Sales.Where(x => x.IdVenta == id).FirstOrDefault();

            return venta;
        }
        public Venta PostSale(Venta venta)
        {
            Sales.Add(venta);

            return venta;
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
