using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;
using System.IO;
using Newtonsoft.Json;

namespace Xy.SuperStore.Data.Repository
{
    public class JsonProductRepository : IProductRepository
    {
        private const string ProductJsonFile = "C:\\temp\\ProductData.json";

        public void AddProduct(int id, string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name can not be bull or white space!");
            }
            if (price < 0)
            {
                throw new ArgumentException("Price must be larger than 0.");
            }
            if (quantity<0)
            {
                throw new ArgumentException("quantity can not be negative. ");
            }
            var products = GetProductsFromJson();
            //var product = GetProductById(id);
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product!=null)
            {
                product.Id = id;
                product.Name = name;
                product.Price = price;
                product.Quantity += quantity;
            }
            else
            {
                product = new Product
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };
                products.Add(product);
            }
            SaveToJson(products);
        }

        
        public void AddProduct(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("quantity can not be negative. ");
            }
            var products = GetProductsFromJson();
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Id = id;
                product.Quantity += quantity;
            }
            else
            {
                throw new ArgumentException($"This id:{id} does not exist in stock, need name & price to add this product!");
            }
            SaveToJson(products);
        }

        public Product GetProductById(int id)
        {
            var products = GetProductsFromJson();
            return products.FirstOrDefault(x => x.Id == id);
        }

        public string ListAllProducts()
        {
            var products = GetProductsFromJson();
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.Append($"{product.ToString()}\n");
            }
      //      Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());
            return sb.ToString();
        }

        public void RemoveProduct(int id, int quantity)
        {
            if (quantity<0)
            {
                throw new ArgumentException("quantity should be bigger than 0.");
            }
            var products = GetProductsFromJson();
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product!=null)
            {
                product.Quantity -= quantity;
                if (product.Quantity<=0)
                {
                    products.Remove(product);
                }
            }
            SaveToJson(products);
        }

        private List<Product> GetProductsFromJson()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductJsonFile));
            }
            catch (Exception)
            {
            }
            return products;

        }

        private void SaveToJson(List<Product> products)
        {
             File.WriteAllText(ProductJsonFile,JsonConvert.SerializeObject(products));
        }
    }
}
