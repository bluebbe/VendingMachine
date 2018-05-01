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
    }
}
