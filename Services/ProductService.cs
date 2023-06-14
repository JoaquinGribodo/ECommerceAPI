using Data.Models;
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

        private ProductService() { }

        public Producto GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Producto> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Producto PutProduct(int id, ProductViewModel producto)
        {
            return _productRepository.PutProduct(id, producto);
        }

        public Producto PostProduct(ProductViewModel producto)
        {
            return _productRepository.PostProduct(producto);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
