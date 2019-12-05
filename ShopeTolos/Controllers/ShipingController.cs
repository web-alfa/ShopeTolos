using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeTolos.Service;

namespace ShopeTolos.Controllers
{
    public class ShipingController : ControllerBase
    {
        private ManagerShope managerShope = new ManagerShope();

        [HttpGet]
        [Route("Shiping")]
        public string GetShiping()
        {
            return managerShope.GetShiping();
        }

        [HttpGet]
        [Route("OneShiping")]
        public string GetOneShiping(string idShiping)
        {
            return managerShope.GetOneShiping(idShiping);
        }

        [HttpGet]
        [Route("Store")]
        public string GetStore()
        {
            return managerShope.GetStore();
        }

        [HttpGet]
        [Route("OneStore")]
        public string GetOneStore(string idStore)
        {
            return managerShope.GetOneStore(idStore);
        }
    }
}