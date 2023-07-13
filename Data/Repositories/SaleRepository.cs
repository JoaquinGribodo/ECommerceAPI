using AutoMapper;
using Data.Mappings;
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
        private readonly IMapper _mapper;

        public SaleRepository(ECommerceDBContext eCommerceDBContext)
        {
            _dbContext = eCommerceDBContext;
            _mapper = AutoMapperConfig.Configure();
        }
        public List<SaleDTO> GetSales()
        {
            return _mapper.Map<List<SaleDTO>>(_dbContext.Venta.ToList());
        }

        public SaleDTO GetSaleById(int id)
        {
            return _mapper.Map<SaleDTO>(_dbContext.Venta.FirstOrDefault(x => x.Id == id));

        }
        public SaleDTO PostSale(SaleViewModel venta)
        {
            var product = _dbContext.Producto.FirstOrDefault(p => p.Id == venta.IdProducto);
            if (product == null)
            {
                return new SaleDTO {MontoTotal = 0};
            }
            else
            {
                var sale = new Venta()
                {
                    IdProducto = venta.IdProducto,
                    IdUsuario = venta.IdUsuario,
                    FechaVenta = venta.FechaVenta,
                    MontoTotal = product.PrecioUnitario,
                };
                _dbContext.Venta.Add(sale);
                _dbContext.SaveChanges();

                return _mapper.Map<SaleDTO>(sale);
            }
        }

        public SaleDTO PutSale(SaleViewModel venta)
        {
            Venta ventaDataBase = _dbContext.Venta.Single(f => f.Id == venta.Id);
            ventaDataBase.FechaVenta = venta.FechaVenta;
            ventaDataBase.IdProducto = venta.IdProducto;
            ventaDataBase.IdUsuario = venta.IdUsuario;
            ventaDataBase.MontoTotal = venta.MontoTotal;

            _dbContext.SaveChanges();

            var lastSale = _dbContext.Venta.OrderBy(x => x.Id).Last();
            return _mapper.Map<SaleDTO>(lastSale);
        }
        public void DeleteSale(int id)
        {
            _dbContext.Venta.Remove(_dbContext.Venta.Single(w => w.Id == id));
            _dbContext.SaveChanges();
        }
    }
}
