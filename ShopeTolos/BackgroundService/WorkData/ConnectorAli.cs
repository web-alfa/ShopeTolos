﻿using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using DBOTool.Model;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xNet;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class ConnectorAli : IJob
    {
        private List<string> proxyCloction = null;
        private HttpRequest httpRequest = null;
        private string url = "aliexpress.com/store/feedback-score/";
        private SqlCommandTools sqlCommandTools = null;
       private  HtmlParser htmlParser = null;

        public void Execute()
        {
            sqlCommandTools = new SqlCommandTools();
            htmlParser = new HtmlParser();
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

        private async void WorkParseAndAddDBShope()
        {
            List<OfferOrder> offerOrders = await sqlCommandTools.GetOfferOrders();
            foreach(OfferOrder offerOrder in offerOrders)
            {
                Store store = GetReityngs(offerOrder.Store_id);
                if (store != null)
                {
                    if (sqlCommandTools.CheckShope(offerOrder.Store_id))
                    {
                        if (sqlCommandTools.CheckUpdateShope(offerOrder.Store_id))
                        {
                            sqlCommandTools.UpdateStore(store);
                        }
                    }
                    else
                    {
                        store.IDShope = offerOrder.Store_id;
                        sqlCommandTools.AddStore(store);
                    }
                }
            }
        }

        private Store GetReityngs(int idStore)
        {
            string srciFrame = null;
            Store store = null;
            string htm = httpRequest.Get($"{url}{idStore}.html").ToString();
            IHtmlDocument htmlDocument = htmlParser.ParseDocument(htm);
            srciFrame = GetIFrame(htmlDocument);
            if(srciFrame != null)
            {
                store = new Store();
                   htm = httpRequest.Get(srciFrame).ToString();
                htmlDocument = htmlParser.ParseDocument(htm);
                SetHeadInfo(store, htmlDocument);
            }
            return store;
        }

        private string GetIFrame(IHtmlDocument htmlDocument)
        {
            string srciFrame = null;
            var element = htmlDocument.GetElementById("detail-displayer");
            if(element != null)
            {
                srciFrame = element.GetAttribute("src").Remove(0, 2);
            }
            return srciFrame;
        }

        private void SetHeadInfo(Store store, IHtmlDocument htmlDocument)
        {
            store.Name = htmlDocument.GetElementById("feedback-summary").GetElementsByTagName("tr")[0].TextContent.Replace("Seller:", "").Trim();
            store.StartOfSales = htmlDocument.GetElementById("feedback-summary").GetElementsByTagName("tr")[2].Children[1].TextContent.Trim();
            var tmp = htmlDocument.GetElementById("feedback-dsr").GetElementsByTagName("tr")[0].GetElementsByTagName("td")[0].Children[0].Children[0].OuterHtml;
            tmp = tmp.Remove(0, tmp.IndexOf(':') + 1);
            store.ItemAsDescribed = tmp.Remove(tmp.IndexOf(';'));
            tmp = htmlDocument.GetElementById("feedback-dsr").GetElementsByTagName("tr")[1].GetElementsByTagName("td")[0].Children[0].Children[0].OuterHtml;
            tmp = tmp.Remove(0, tmp.IndexOf(':') + 1);
            store.Communication = tmp.Remove(tmp.IndexOf(';'));
            tmp = htmlDocument.GetElementById("feedback-dsr").GetElementsByTagName("tr")[2].GetElementsByTagName("td")[0].Children[0].Children[0].OuterHtml;
            tmp = tmp.Remove(0, tmp.IndexOf(':') + 1);
            store.ShippingSpeed = tmp.Remove(tmp.IndexOf(';'));
            store.Positive4_5Stars = htmlDocument.GetElementById("feedback-history").Children[1].Children[0].Children[0].Children[1].Children[3].TextContent;
            store.Neutral3Stars = htmlDocument.GetElementById("feedback-history").Children[1].Children[0].Children[0].Children[2].Children[3].TextContent;
            store.Negative1_2Stars = htmlDocument.GetElementById("feedback-history").Children[1].Children[0].Children[0].Children[3].Children[3].TextContent;
            store.DateUpdate = DateTime.Now.ToString();
        }
    }
}