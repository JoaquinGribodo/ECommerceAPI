using Data.Models;
using Data.Models.DTO;
using Data.Models.ViewModel;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private ProductRepository _productRepository { get; set; }

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDTO GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<ProductDTO> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public void PutProduct(int id, ProductViewModel producto)
        {
            _productRepository.PutProduct(id, producto);
        }

        public ProductDTO PostProduct(ProductViewModel producto)
        {
            return _productRepository.PostProduct(producto);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
