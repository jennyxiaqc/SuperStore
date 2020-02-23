using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;

namespace Xy.SuperStore.Data.Repository
{
    public interface IProductRepository
    {
        void AddProduct(int id, string name, decimal price, int quantity);
        void AddProduct(int id,int quantity);
        void RemoveProduct(int id, int quantity);
        Product GetProductById(int id);
        string ListAllProducts();


    }
}
