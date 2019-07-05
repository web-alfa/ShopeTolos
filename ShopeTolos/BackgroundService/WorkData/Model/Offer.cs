using DBOTool.Model;
using System.Collections.Generic;

namespace ShopeTolos.BackgroundService.WorkData.Model
{
    public class Offer
    {
        public string id { get; set; }
        public int id_category { get; set; }
        public int store_id { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}