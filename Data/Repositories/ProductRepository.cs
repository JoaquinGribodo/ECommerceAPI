using Data.Entities;
using Data.Models;
using Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository
    {
        public List<Producto> GetProducts()
        {
            return Products;
        }

        public Producto GetProductById(int id)
        {
            Producto producto = Products.Where(x => x.IdProducto == id).FirstOrDefault();

            return producto;
        }
        public Producto PostProduct(Producto producto)
        {
            Products.Add(producto);

            return producto;
        }
        public List<Producto> PutProduct(int id, Producto producto)
        {
            var productoAModificar = Products.Where(x => x.IdProducto == id).First();
            productoAModificar.Id = producto.Id;
            productoAModificar.Descripcion = producto.Nombre;
            productoAModificar.SubTotal = producto.Apellido;
            productoAModificar.PrecioUnitario = producto.IdRol;

            return Users;
        }
        public void DeleteProduct(int id)
        {
            Producto producto = Products.Where(w => w.Id == id).First();
            Products.Remove(producto);
        }
    }
}
