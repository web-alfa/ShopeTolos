using System.Collections.Generic;
using System;
using xNet;
using FluentScheduler;
using System.Threading.Tasks;
using DBOTool.Model;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class ConnectorAli : IJob
    {
        private List<string> proxyCloction = null;
        private HttpRequest httpRequest = null;
        private string url = "aliexpress.com/store/feedback-score/";
        private SqlCommandTools sqlCommandTools = null;

        public void Execute()
        {
            sqlCommandTools = new SqlCommandTools();
            proxyCloction = new List<string>()
            {
                "118.99.113.14:3128",
                "51.255.132.59:3128",
                "51.75.75.193:3128",
                "176.9.192.215:3128",
                "46.4.115.48:3128",
                "84.16.227.128:3128",
                "207.180.253.113:3128",
                "209.97.191.169:3128",
            };
            httpRequest = new HttpRequest();
            ProxyClient proxyClient = ProxyClient.Parse(ProxyType.Http, "212.237.57.103:8080");
            //httpRequest.Proxy = proxyClient;
            Task.Run(() => WorkParseAndAddDBShope());
        }

        private void WorkParseAndAddDBShope()
        {
            List<OfferOrder> offerOrders = sqlCommandTools.GetOfferOrders();
            foreach(OfferOrder offerOrder in offerOrders)
            {
                if(sqlCommandTools.CheckUpdateShope(offerOrder.Store_id))
                {
                    GetReityngs(offerOrder.Store_id);
                }
                else
                {
                    GetReityngs(offerOrder.Store_id);
                }
            }
        }

        private void GetReityngs(int idStore)
        {
            var htm = httpRequest.Get($"{url}{idStore}.html").ToString();
        }
    }
}