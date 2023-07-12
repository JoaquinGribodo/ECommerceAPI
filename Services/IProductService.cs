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
        ProductDTO GetProductByDescription(string description);
        List<ProductDTO> GetTopSellingProducts(int top);
        ProductDTO PostProduct(ProductViewModel producto);
        ProductDTO PutProduct(ProductViewModel producto);
        void DeleteProduct(int id);
    }
}
