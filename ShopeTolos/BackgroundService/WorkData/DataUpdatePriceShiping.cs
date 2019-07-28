using DBOTool.Model;
using FluentScheduler;
using ShopeTolos.BackgroundService.WorkData.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class DataUpdatePriceShiping : IJob
    {
        private SqlCommandTools sqlCommandTools = null;
        private ConnectorEPN connectorEPN = null;

        public void Execute()
        {
            sqlCommandTools = new SqlCommandTools();
            connectorEPN = new ConnectorEPN();
            Task.Run(() => WorkUpdatePrice());
        }

        private async void WorkUpdatePrice()
        {
            List<OfferOrder> offerOrders = await sqlCommandTools.GetOfferOrders();
            for (int i = 0; i < offerOrders.Count; i++)
            {
                try
                {
                    if (sqlCommandTools.CheckPrice(offerOrders[i].Id))
                    {
                        PriceOffer priceOffer = new PriceOffer();
                        priceOffer.DatateUpdate = DateTime.Now.ToString();
                        Offer offer = connectorEPN.GetOffer(offerOrders[i].Id);
                        priceOffer.Price = offer.price;
                        sqlCommandTools.AddPrice(offer.id, priceOffer);
                    }
                }
                catch (Exception e)
                {
                    File.AppendAllText("log/WorkUpdatePrice.txt", $"{e.Message} {Environment.NewLine}");
                }
            }
        }
    }
}
