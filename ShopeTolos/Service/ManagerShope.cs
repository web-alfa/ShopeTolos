using DBOTool.Model;
using Newtonsoft.Json;
using ShopeTolos.BackgroundService;
using System.Collections.Generic;

namespace ShopeTolos.Service
{
    public class ManagerShope
    {
        private SqlCommandTools sqlCommandTools = null;

        public ManagerShope()
        {
            sqlCommandTools = new SqlCommandTools();
        }

        public string GetShiping()
        {
            List<OfferOrder> offerOrders = sqlCommandTools.GetShiping();
            return offerOrders.Count.ToString();
        }

        public string GetStore()
        {
            List<Store> stores = sqlCommandTools.GetStore();
            return stores.Count.ToString();
        }
    }
}