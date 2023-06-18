using Data.Models;
using Data.Models.DTO;
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
        public List<SaleDTO> GetSales()
        {
            List<SaleDTO> response = new List<SaleDTO>();
            List<Venta> sales = _dbContext.Venta.ToList();
            foreach (var sale in sales)
            {
                response.Add(new SaleDTO()
                {
                    Id = sale.Id,
                    IdProducto = sale.IdProducto,
                    IdUsuario = sale.IdUsuario,
                    FechaVenta = sale.FechaVenta,
                    MontoTotal = sale.MontoTotal,
                });
            }
            return response;
        }

        public SaleDTO GetSaleById(int id)
        {
            SaleDTO response = new SaleDTO();
            Venta venta = _dbContext.Venta.FirstOrDefault(x => x.Id == id);
            if (venta != null)
            {
                response.Id = venta.Id;
                response.IdProducto = venta.IdProducto;
                response.IdUsuario = venta.IdUsuario;
                response.FechaVenta = venta.FechaVenta;
                response.MontoTotal = venta.MontoTotal;

            }
            return response;
        }
        public SaleDTO PostSale(SaleViewModel venta) 
        {                                                        
            _dbContext.Venta.Add(new Venta()
            {
                IdProducto = venta.IdProducto,
                IdUsuario = venta.IdUsuario,
                FechaVenta = venta.FechaVenta,
                MontoTotal = venta.MontoTotal,
            });
            _dbContext.SaveChanges();

            var addedSale = _dbContext.Venta.OrderBy(x => x.Id).Last();
            SaleDTO response = new SaleDTO()
            {
                Id = addedSale.Id,
                IdUsuario = addedSale.IdUsuario,
                IdProducto = addedSale.IdProducto,
                FechaVenta = addedSale.FechaVenta,
                MontoTotal = addedSale.MontoTotal,
            };
            return response;
        }
        public void PutSale(int id, SaleViewModel venta)
        {
            SaleDTO response = new SaleDTO();
            var ventaAModificar = _dbContext.Venta.FirstOrDefault(x => x.Id == id);
            if (venta != null)
            {
                ventaAModificar.IdProducto = venta.IdProducto;
                ventaAModificar.IdUsuario = venta.IdUsuario;
                ventaAModificar.FechaVenta = venta.FechaVenta;
                ventaAModificar.MontoTotal = venta.MontoTotal;

                _dbContext.SaveChanges();
            }
        }
        public void DeleteSale(int id)
        {
            Venta venta = _dbContext.Venta.First(w => w.Id == id);
            if (venta != null)
            {
                _dbContext.Venta.Remove(venta);
                _dbContext.SaveChanges();
            }
        }
    }
}
