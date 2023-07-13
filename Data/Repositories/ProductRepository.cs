using AutoMapper;
using Azure;
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
    public class ProductRepository
    {

        private readonly ECommerceDBContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ECommerceDBContext eCommerceDBContext) { 
            _dbContext = eCommerceDBContext;
            _mapper = AutoMapperConfig.Configure();
        }
        public List<ProductDTO> GetProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_dbContext.Producto.ToList());

        }

        public ProductDTO GetProductById(int id)
        {
            return _mapper.Map<ProductDTO>(_dbContext.Producto.FirstOrDefault(x => x.Id == id));

        }

        public ProductDTO GetProductByDescription(string description)
        {
            return _mapper.Map<ProductDTO>(_dbContext.Producto.FirstOrDefault(x => x.Descripcion.ToLower() == description.ToLower()));
        }
        public List<ProductDTO> GetTopSellingProducts(int top)
        {
            var topSellingProducts = _dbContext.Venta
                .GroupBy(v => v.IdProducto)
                .Select(g => new { IdProducto = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(top)
                .ToList();

            var topSellingProductIds = topSellingProducts.Select(x => x.IdProducto).ToList();

            var products = _dbContext.Producto
                .Where(p => topSellingProductIds.Contains(p.Id))
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Descripcion = p.Descripcion,
                    PrecioUnitario = p.PrecioUnitario
                })
                .ToList();

            return products;
        }

        public ProductDTO PostProduct(ProductViewModel producto) //ViewModel: ingresa un producto nuevo
        {                                                        //DTO: trae datos de la BD para el frontend
            _dbContext.Producto.Add(new Producto()
            {
                Descripcion = producto.Descripcion,
                PrecioUnitario= producto.PrecioUnitario
            });
            _dbContext.SaveChanges();

            var lastProduct = _dbContext.Producto.OrderBy(x => x.Id).Last();

            return _mapper.Map<ProductDTO>(lastProduct);
        }
        public ProductDTO PutProduct(ProductViewModel producto)
        {
            Producto productoDataBase = _dbContext.Producto.Single(f => f.Id == producto.Id);

            productoDataBase.Descripcion = producto.Descripcion;
            productoDataBase.PrecioUnitario = producto.PrecioUnitario;

            _dbContext.SaveChanges();

            var lastProduct = _dbContext.Producto.OrderBy(x => x.Id).Last();
            return _mapper.Map<ProductDTO>(lastProduct);
        }
        public void DeleteProduct(int id)
        {
            _dbContext.Producto.Remove(_dbContext.Producto.Single(w => w.Id == id));
            _dbContext.SaveChanges();
        }
    }
}
