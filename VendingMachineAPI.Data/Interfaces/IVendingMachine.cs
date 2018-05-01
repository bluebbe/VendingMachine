using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineAPI.Data.Model;

namespace VendingMachineAPI.Data.Interfaces
{
    public interface IVendingMachine
    {
        IEnumerable<Item> getAllItems();
        Item getItemById(int paramInt);
        void updateItem(Item paramItem);
        Item peristItem(Item paramItem);
        void deleteItem(int paramInt);
    }
}
