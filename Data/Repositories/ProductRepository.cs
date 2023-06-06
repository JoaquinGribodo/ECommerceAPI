using Data.Entities;
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
        public static List<Product> Products = new List<Product>()
        {
            new Product
            {
            Id = 1,
            Name = "product1",
            Description = "description1"
            },
            new Product
            {
            Id = 2,
            Name = "product2",
            Description = "description2"
            },
        };
        public Product? GetProductById(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }
        public List<Product?> GetProducts()
        {
            return Products;
        }
        public void PostProduct(Product product)
        {
            Products.Add(product);
        }
        public void PutProduct(int id)
        {
            Products;
        }
        public void DeleteProduct(int id)
        {
            Products.Remove(x => x.Id == id);
        }
    }
}
