using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopeTolos.Model;
using ShopeTolos.Service;
using System.Threading.Tasks;

namespace ShopeTolos.Controllers
{
    public class ApiServerController : ControllerBase
    {
        private ManagerShope managerShope = new ManagerShope();

        [HttpPost]
        [Route("Statistics")]
        public async Task<string> GetStatistics(string idShiping)
        {
            var s = Request;
            string res = "";
            if (idShiping != null && idShiping != "")
            {
                res = JsonConvert.SerializeObject(await managerShope.GetStatistics(idShiping));
            }
            else
            {
                Response response = new Response();
                ResponseOrder responseOrder = new ResponseOrder();
                ResponseStore responseStore = new ResponseStore();
                responseOrder.Status = "No_Content";
                responseStore.Status = "No_Content";
                response.ResponseOrder = responseOrder;
                response.ResponseStore = responseStore;
                res = JsonConvert.SerializeObject(response);
            }
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return res;
        }
    }
}