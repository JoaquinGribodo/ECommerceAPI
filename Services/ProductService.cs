using Data.Entities;
using Data.Models.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        ProductRepository _productRepository = new ProductRepository();
        public Product GetUserById(int id)
        {
            return _productRepository.GetUserById(id);
        }
        public Product GetUsers()
        {
            return _productRepository.GetUsers();

        }
        public Product PostUser()
        {
            return _productRepository.PostUser();

        }
        public Product PutUser(int id)
        {
            return _productRepository.PutUser(id);

        }
        public Product DeleteUser(int id)
        {
            return _productRepository.DeleteUser(id);

        }
    }
}
