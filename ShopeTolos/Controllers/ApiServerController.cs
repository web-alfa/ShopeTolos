using Microsoft.AspNetCore.Mvc;
using ShopeTolos.Service;

namespace ShopeTolos.Controllers
{
    public class ApiServerController : ControllerBase
    {
        private ManagerShope managerShope = new ManagerShope();

        [HttpPost]
        [Route("Statistics")]
        public void GetStatistics()
        {

        }
    }
}