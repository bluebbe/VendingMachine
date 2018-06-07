using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineAPI.Data.Interfaces;
using VendingMachineAPI.Data.Model;
using System.Data.SqlClient;
using System.Data;

namespace VendingMachineAPI.Data.ADO
{
    public class VendingMachineADORepository : IVendingMachine
    {
        public void deleteItem(int paramInt)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> getAllItems()
        {
            List<Item> listings = new List<Item>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VendingItemsById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Item row = new Item();

                        row.Id = (int)dr["Id"];
                        row.Name = dr["Name"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Quantity = (int)dr["Quantity"];
                        
                        listings.Add(row);
                    }
                }
            }

            return listings;
        }

        public Item getItemById(int paramInt)
        {
            throw new NotImplementedException();
        }

        public Item peristItem(Item paramItem)
        {
            throw new NotImplementedException();
        }

        public void updateItem(Item paramItem)
        {
            throw new NotImplementedException();
        }

        
    }
}