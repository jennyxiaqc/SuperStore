using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;

namespace Xy.SuperStore.UI.ShoppingConsole
{
    public class Printer
    {
        public static void PrintReceipt(Receipt receipt)
        {

            Console.WriteLine($"ReceiptId:{receipt.ReceiptId}");
            Console.WriteLine("=======================");
            foreach (var shoppingItem in receipt.ReceiptItems)
            {
                Console.WriteLine($"{shoppingItem.ToString()}");
            }
            Console.WriteLine($"Total quantity:{receipt.TotalQuantity}");
            Console.WriteLine($"Total amount:{receipt.TotalAmount}");
        }

    }
}
