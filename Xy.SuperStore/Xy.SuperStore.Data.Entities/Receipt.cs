using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xy.SuperStore.Data.Entities
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public List<ShoppingItem> ReceiptItems { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Re");
            sb.Append($"ReceiptId:{ReceiptId}\n");
            sb.Append("=======================\n");
            foreach (var shoppingItem in ReceiptItems)
            {
                sb.Append($"{shoppingItem.ToString()}\n");
            }
            sb.Append($"Total quantity:{TotalQuantity}\n");
            sb.Append($"Total amount: ${TotalAmount}\n");
            return sb.ToString();
        }
    }
}
