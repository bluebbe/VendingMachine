using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using VendingMachineAPI.Data.Factories;
using VendingMachineAPI.Data.Model;
using VendingMachineAPI.Models;
using System.Net.Http.Formatting;
using VendingMachineAPI.Data.Interfaces;

namespace VendingMachineAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {

        private readonly IVendingMachine repo = VendingMachineRepoFactory.GetRepository();

        

        [Route("items")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getAllItems()
        {
            
            List<Item> items = repo.getAllItems().ToList();

            return Json(items, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        [Route("money/{money}/item/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult vendItems(decimal money,int id)
        {
           

            Item item = repo.getItemById(id);
            if (item.Quantity < 1)
            {

                return new VendingMachineAPI.Models.MessageResult("{ \"message\" : \"SOLD OUT!!!\" }",Request);

            }

            if (money.CompareTo(item.Price) < 0)
            {
                decimal diff = item.Price - money;
                var msg = "{ \"message\" : \"Please deposit: $" + diff + " \" }";
                return new VendingMachineAPI.Models.MessageResult(msg, Request);

            }

            item.Quantity = item.Quantity - 1;

            repo.updateItem(item);

            decimal changeAmount = money - item.Price;

            changeAmount = changeAmount * 100;
            int pennies = (int)changeAmount;

            var change = new Change(pennies);

            
            

            return Json(change, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
