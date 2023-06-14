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
        public List<Producto> GetProducts()
        {
            return _dbContext.Producto.ToList();
        }

        public ProductDTO GetProductById(int id)
        {
            Producto producto = _dbContext.Producto.Where(x => x.Id == id).FirstOrDefault();
            ProductDTO productDTO = new ProductDTO()
            {
                Id = producto.Id,
                Descripcion = producto.Descripcion,
                SubTotal = producto.SubTotal,
                PrecioUnitario = producto.PrecioUnitario
            };

            return productDTO;
        }
        public Producto PostProduct(ProductViewModel producto) //ViewModel: ingresa un producto nuevo
        {                                                        //DTO: trae datos de la BD para el frontend
            Producto producto1 = new Producto()
            {
                Descripcion = producto.Descripcion,
                SubTotal = producto.SubTotal,
                PrecioUnitario = producto.PrecioUnitario
            };
            _dbContext.Producto.Add(producto1);
            _dbContext.SaveChanges();

            return producto1;
        }
        public Producto PutProduct(int id, ProductViewModel producto)
        {
            var productoAModificar = _dbContext.Producto.Where(x => x.Id == id).FirstOrDefault();
            productoAModificar.Descripcion = producto.Descripcion;
            productoAModificar.SubTotal = producto.SubTotal;
            productoAModificar.PrecioUnitario = producto.PrecioUnitario;

            return productoAModificar;
        }
        public void DeleteProduct(int id)
        {
            Producto producto = _dbContext.Producto.Where(w => w.Id == id).FirstOrDefault();
            _dbContext.Producto.Remove(producto);
            _dbContext.SaveChanges();
        }
    }
}
