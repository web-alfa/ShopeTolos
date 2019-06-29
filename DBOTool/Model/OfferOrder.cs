namespace DBOTool.Model
{
    public class OfferOrder
    {
        public string id { get; set; }
        public int id_category { get; set; }
        public int store_id { get; set; }
        public double price { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}