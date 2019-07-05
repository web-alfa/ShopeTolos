namespace DBOTool.Model
{
    public class Store
    {
        public int ID { get; set; }
        public bool IsUodateToDay { get; set; }
        public string DateUpdate { get; set; }
        public string Name { get; set; }
        public string StartOfSales { get; set; }
        public string ItemAsDescribed { get; set; }
        public string Communication { get; set; }
        public string ShippingSpeed { get; set; }
        public string Positive4_5Stars { get; set; }
        public string Neutral3Stars { get; set; }
        public string Negative1_2Stars { get; set; }
        public bool IsTopShope { get; set; }
    }
}