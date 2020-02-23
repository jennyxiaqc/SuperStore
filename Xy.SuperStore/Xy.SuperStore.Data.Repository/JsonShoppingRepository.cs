using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;
using System.IO;

namespace Xy.SuperStore.Data.Repository
{
    public class JsonShoppingRepository : IShoppingRepository
    {
        string filename = "c:\\temp\\LastReceiptId.Txt";
        public int GetReceiptId()
        {
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, "1");
                return 1;
            }
            else
            {
                return 1 + int.Parse(File.ReadAllText(filename));
            }

        }

        public void SaveReceipt(Receipt receipt)
        {
            string filename = "C:\\temp\\ReceiptData.txt";
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(receipt.ToString());
            };


        }
    }
}
