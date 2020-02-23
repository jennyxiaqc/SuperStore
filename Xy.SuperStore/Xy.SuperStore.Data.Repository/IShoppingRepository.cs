using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xy.SuperStore.Data.Entities;

namespace Xy.SuperStore.Data.Repository
{
    public interface IShoppingRepository
    {
        int GetReceiptId();
        void SaveReceipt(Receipt receipt);
    }
}
