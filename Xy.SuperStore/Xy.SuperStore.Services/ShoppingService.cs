using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;
using Xy.SuperStore.Data.Repository;

namespace Xy.SuperStore.Services
{
    public class ShoppingService
    {
        private readonly ProductService _productService = new ProductService();
        private IShoppingRepository _shoppingRepository = new JsonShoppingRepository();             

        public ShoppingItem AddShoppingItem(ShoppingCart shoppingCart, int productId, int quantity = 1)
        {
            if (shoppingCart==null)
            {
                throw new ArgumentException();
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("quantity must be bigger than 0");
            }
            Product product = _productService.GetPRoductById(productId);
            if (product != null)
            {
                if (product.Quantity < quantity)
                {
                    throw new ArgumentException("Not enough stock!");
                }
 
                var   shoppingItem = shoppingCart.ShoppingItems.FirstOrDefault(x => x.ProductId == productId);
               
                if (shoppingItem != null)
                {
                    shoppingItem.ProductQuantity += quantity;
                    shoppingItem.ProductTotalPrice = shoppingItem.ProductPrice * shoppingItem.ProductQuantity;
                }
                else
                {
                    shoppingItem = new ShoppingItem
                    {
                        ProductId = productId,
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        ProductQuantity = quantity,
                        ProductTotalPrice = product.Price * quantity
                    };
                    shoppingCart.ShoppingItems.Add(shoppingItem);
                }
                _productService.RemoveProduct(productId, quantity);
                return shoppingItem;
            }
            else
            {
                throw new ArgumentException($"This product Id={productId} no stock.");
            }
        }

        public ShoppingItem RemoveFromCart(ShoppingCart shoppingCart,int id, int quantity=1)
        {
            ShoppingItem result = new ShoppingItem();
            if (shoppingCart==null)
            {
                throw new ArgumentNullException();
            }
            ShoppingItem shoppingItem = shoppingCart.ShoppingItems.FirstOrDefault(x => x.ProductId == id);
            if (shoppingItem!=null)
            {
                int removeQty = shoppingItem.ProductQuantity < quantity ? shoppingItem.ProductQuantity : quantity; 
                shoppingItem.ProductQuantity -= removeQty;
                if (shoppingItem.ProductQuantity<=0)
                {
                    shoppingCart.ShoppingItems.Remove(shoppingItem);
                     result = null;
                }
                else 
                { 
                shoppingItem.ProductTotalPrice = shoppingItem.ProductPrice * shoppingItem.ProductQuantity;
                result = shoppingItem;
                }
                _productService.AddProduct(id, shoppingItem.ProductName,shoppingItem.ProductPrice,removeQty);
                return result;
            }
            else
            {
                throw new ArgumentException($"No this item Id= {id} in shopping cart.");
            }
        }

        public void SaveReceipt(Receipt receipt)
        {
            _shoppingRepository.SaveReceipt(receipt);
        }

        public string CheckShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart==null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder sb = new StringBuilder();
            foreach (var shoppingItem in shoppingCart.ShoppingItems)
            {
                sb.Append($"{shoppingItem.ToString()}\n");
            }
            return sb.ToString();
        }

        public Receipt Checkout(ShoppingCart shoppingCart)
        {
            Receipt receipt = new Receipt();
            if (shoppingCart==null)
            {
                throw new ArgumentNullException();
            }
            receipt.ReceiptId = _shoppingRepository.GetReceiptId();
            receipt.ReceiptItems = shoppingCart.ShoppingItems;
            receipt.TotalQuantity = receipt.ReceiptItems.Sum(x => x.ProductQuantity);
            receipt.TotalAmount = receipt.ReceiptItems.Sum(x => x.ProductTotalPrice);
            return receipt;
         
        }
    }
}
