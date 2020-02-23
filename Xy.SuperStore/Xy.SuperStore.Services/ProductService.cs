using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;
using Xy.SuperStore.Data.Repository;

namespace Xy.SuperStore.Services
{
    public class ProductService
    {
        private IProductRepository _productRepository = new JsonProductRepository();

        public Product AddProduct(int id,string name, decimal price, int quantity)
        {
            _productRepository.AddProduct(id, name, price, quantity);
            return _productRepository.GetProductById(id);
        }

        public Product AddProduct(int id, int quantity)
        {
            _productRepository.AddProduct(id, quantity);
            return _productRepository.GetProductById(id);
        }

        public Product RemoveProduct(int id, int quantity)
        {
            _productRepository.RemoveProduct(id, quantity);
            return _productRepository.GetProductById(id);
        }

        public Product GetPRoductById(int id)
        {
          return  _productRepository.GetProductById(id);
        }

        public string ListAllProducts()
        {
            return _productRepository.ListAllProducts();
        }

    }
}
