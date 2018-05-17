using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using VendingMachineAPI.Data.Factories;
using VendingMachineAPI.Data.Model;
using VendingMachineAPI.Models;

namespace VendingMachineAPI.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
        [Route("items")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getAllItems()
        {
            var repo = VendingMachineRepoFactory.GetRepository();
            List<Item> items = repo.getAllItems().ToList();

            return Json(items, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        [Route("money/{money}/item/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult vendItems(decimal money,int id)
        {
            var repo = VendingMachineRepoFactory.GetRepository();

            Item item = repo.getItemById(id);
            if (item.Quantity < 1)
            {
                throw new NotImplementedException();
            }

            if(money.CompareTo(item.Price) < 0)
            {
                throw new NotImplementedException();
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
