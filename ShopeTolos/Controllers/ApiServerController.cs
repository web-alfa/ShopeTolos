using Microsoft.AspNetCore.Mvc;
using ShopeTolos.Service;

namespace ShopeTolos.Controllers
{
    public class ApiServerController : ControllerBase
    {
        private ManagerShope managerShope = new ManagerShope();

        [HttpGet]
        [Route("Statistics")]
        public void GetStatistics(string idShope, string idShiping)
        {
            if ((idShope != null && idShope != "") && (idShiping != null && idShiping != ""))
            {
                managerShope.GetStatistics(idShope, idShiping);
            }
        }
    }
}