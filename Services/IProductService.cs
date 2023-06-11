using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        List<Producto> GetProducts();
        Producto GetProductById(int id);
        Producto PostProduct(Producto producto);
        List<Producto> PutProduct(int id, Producto producto);
        void DeleteProduct(int id);
    }
}
