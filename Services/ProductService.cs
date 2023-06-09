﻿using Data.Models;
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

        public ProductDTO GetProductByDescription(string description)
        {
            return _productRepository.GetProductByDescription(description);
        }

        public List<ProductDTO> GetTopSellingProducts(int top) 
        {
            return _productRepository.GetTopSellingProducts(top);
        }
        public List<ProductDTO> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public ProductDTO PutProduct(ProductViewModel producto)
        {
            return _productRepository.PutProduct(producto);
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
