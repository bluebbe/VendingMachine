using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineAPI.Data.Interfaces;
using VendingMachineAPI.Data.Model;

namespace VendingMachineAPI.Data.MockRepository
{
    public class VendingMachineMockRepository : IVendingMachine
    {
        private List<Item> vendingItems;

        public VendingMachineMockRepository()
        {
            vendingItems = new List<Item>();

            vendingItems.Add(new Item { Id = 1, Name = "Snickers", Price = (decimal)1.50, Quantity = 10 });
            vendingItems.Add(new Item { Id = 2, Name = "M&M's", Price = (decimal)1.25, Quantity = 8 });
            vendingItems.Add(new Item { Id = 3, Name = "Almond", Price = (decimal)1.25, Quantity = 11 });
            vendingItems.Add(new Item { Id = 4, Name = "Milky Way", Price = (decimal)1.65, Quantity = 3 });
            vendingItems.Add(new Item { Id = 5, Name = "PayDay", Price = (decimal)1.75, Quantity = 2 });
            vendingItems.Add(new Item { Id = 6, Name = "Reese's", Price = (decimal)1.50, Quantity = 5 });
            vendingItems.Add(new Item { Id = 7, Name = "Pringles", Price = (decimal)2.35, Quantity = 4 });
            vendingItems.Add(new Item { Id = 8, Name = "Cheezits", Price = (decimal)2.00, Quantity = 6 });
            vendingItems.Add(new Item { Id = 9, Name = "Doritos", Price = (decimal)1.95, Quantity = 7 });

        }

       
        

        public void deleteItem(int paramInt)
        {
            vendingItems.Remove(getItemById(paramInt));
           
        }

        public IEnumerable<Item> getAllItems()
        {
            return vendingItems;
        }

        public Item getItemById(int paramInt)
        {
            return vendingItems.Where(i => paramInt == i.Id).FirstOrDefault();
        }

        public Item peristItem(Item paramItem)
        {
            throw new NotImplementedException();
        }

        public void updateItem(Item paramItem)
        {
            
            deleteItem(paramItem.Id);
            vendingItems.Add(paramItem);
   
        }
    }
}