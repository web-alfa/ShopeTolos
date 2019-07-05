using System.Collections.Generic;

namespace DBOTool.Model
{
    public class OfferOrder
    {
        public string Id { get; set; }
        public int Id_category { get; set; }
        public int Store_id { get; set; }
        public List<PriceOffer> PriceOffers { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}