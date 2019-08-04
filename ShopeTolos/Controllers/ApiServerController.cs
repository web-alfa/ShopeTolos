using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopeTolos.Service;

namespace ShopeTolos.Controllers
{
    public class ApiServerController : ControllerBase
    {
        private ManagerShope managerShope = new ManagerShope();

        [HttpGet]
        [Route("Statistics")]
        public string GetStatistics(string idShope, string idShiping)
        {
            string res = "";
            if ((idShope != null && idShope != "") && (idShiping != null && idShiping != ""))
            {
                res = JsonConvert.SerializeObject(managerShope.GetStatistics(idShope, idShiping));
            }
            return res;
        }
    }
}