using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        ProductDTO GetProductById(int id);
        ProductDTO PostProduct(ProductViewModel producto);
        void PutProduct(int id, ProductViewModel producto);
        void DeleteProduct(int id);
    }
}
