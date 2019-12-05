using DBOTool.Model;
using FluentScheduler;
using ShopeTolos.BackgroundService.WorkData.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class InitShopNew : IJob
    {
        private SqlCommandTools sqlCommandTools = null;
        private ConnectorEPN connectorEPN = null;

        public void Execute()
        {
            sqlCommandTools = new SqlCommandTools();
            connectorEPN = new ConnectorEPN();
            Task.Run(() => WorkShopNew());
        }

        private async void WorkShopNew()
        {
            List<OfferOrder> offerOrders = sqlCommandTools.GetOfferOrders1();
            for (int i = 0; i < offerOrders.Count; i++)
            {
                try
                {
                    if (offerOrders[i].Name == "New")
                    {
                        Offer offer = connectorEPN.GetOffer(offerOrders[i].Id);
                        offerOrders[i].Description = offer.description;
                        offerOrders[i].Id_category = offer.id_category;
                        offerOrders[i].Name = offer.name;
                        offerOrders[i].Store_id = offer.store_id;
                        sqlCommandTools.UpdateShiping(offerOrders[i]);
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
