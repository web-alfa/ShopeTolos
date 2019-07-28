using DBOTool.Model;
using System.Collections.Generic;

namespace ShopeTolos.Model
{
    public class ResponseOrder
    {
        public List<PriceOffer> PriceOffers { get; set; }
        public string Status { get; set; }
    }
}