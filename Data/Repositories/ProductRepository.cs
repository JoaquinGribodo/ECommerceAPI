using Azure;
using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
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
        public ProductRepository(ECommerceDBContext eCommerceDBContext) { 
            _dbContext = eCommerceDBContext;
        }
        public List<ProductDTO> GetProducts()
        {
            List<ProductDTO> response = new List<ProductDTO>();
            List<Producto> products = _dbContext.Producto.ToList();
            foreach (var product in products)
            {
                response.Add(new ProductDTO()
                {
                    Id = product.Id,
                    Descripcion = product.Descripcion,
                    SubTotal = product.SubTotal,
                    PrecioUnitario = product.PrecioUnitario
                });
            }
            return response;
        }

        public ProductDTO GetProductById(int id)
        {
            ProductDTO response = new ProductDTO();
            Producto producto = _dbContext.Producto.FirstOrDefault(x => x.Id == id);
            if (producto != null) 
            {
                response.Id = producto.Id;
                response.Descripcion = producto.Descripcion;
                response.SubTotal = producto.SubTotal;
                response.PrecioUnitario = producto.PrecioUnitario;
            }
            return response;
        }
        public ProductDTO PostProduct(ProductViewModel producto) //ViewModel: ingresa un producto nuevo
        {                                                        //DTO: trae datos de la BD para el frontend
            _dbContext.Producto.Add(new Producto()
            {
                Descripcion = producto.Descripcion,
                SubTotal = producto.SubTotal,
                PrecioUnitario= producto.PrecioUnitario
            });
            _dbContext.SaveChanges();

            var addedProduct = _dbContext.Producto.OrderBy(x => x.Id).Last();
            ProductDTO response = new ProductDTO()
            {
                Id = addedProduct.Id,
                Descripcion = addedProduct.Descripcion,
                SubTotal = addedProduct.SubTotal,
                PrecioUnitario = addedProduct.PrecioUnitario
            };
            return response;
        }
        public void PutProduct(int id, ProductViewModel producto)
        {
            ProductDTO response = new ProductDTO();
            var productoAModificar = _dbContext.Producto.FirstOrDefault(x => x.Id == id);
            if (producto != null)
            {
                productoAModificar.Descripcion = producto.Descripcion;
                productoAModificar.SubTotal = producto.SubTotal;
                productoAModificar.PrecioUnitario = producto.PrecioUnitario;

                _dbContext.SaveChanges();
            }
        }
        public void DeleteProduct(int id)
        {
            Producto producto = _dbContext.Producto.First(w => w.Id == id);
            if(producto != null) 
            {
                _dbContext.Producto.Remove(producto);
                _dbContext.SaveChanges();
            }
        }
    }
}
