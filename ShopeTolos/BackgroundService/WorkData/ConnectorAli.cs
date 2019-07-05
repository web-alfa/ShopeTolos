using System.Collections.Generic;
using System;
using xNet;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class ConnectorAli
    {
        private List<string> proxyCloction = null;
        private HttpRequest httpRequest = null;
        private string url = "aliexpress.com/store/feedback-score";

        public ConnectorAli()
        {
            proxyCloction = new List<string>()
            {
                "118.99.113.14:3128",
                "62.109.27.110:3128",
                "51.255.132.59:3128",
                "51.75.75.193:3128",
                "176.9.192.215:3128",
                "46.4.115.48:3128",
                "84.16.227.128:3128",
                "207.180.253.113:3128",
                "209.97.191.169:3128",
            };
            httpRequest = new HttpRequest()
            {
                Cookies = new CookieDictionary(),
                AllowAutoRedirect = true,
            };
            ProxyClient proxyClient = ProxyClient.Parse(ProxyType.Http, proxyCloction[new Random().Next(0, proxyCloction.Count)]);
            httpRequest.Proxy = proxyClient;
        }

        public void GetReityngs
    }
}