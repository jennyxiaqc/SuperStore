using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.SuperStore.Data.Entities
{
    public class ShoppingItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductTotalPrice { get; set; }

        public override string ToString()
        {
            return $"Shopping Item: Id={ProductId},Name={ProductName},Price={ProductPrice},Quantity={ProductQuantity},Total Price={ProductTotalPrice}";
        }
    }
}
