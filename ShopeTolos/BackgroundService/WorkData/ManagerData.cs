using DBOTool.Model;
using ShopeTolos.BackgroundService.WorkData.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class ManagerData
    {
        private SqlCommandTools sqlCommandTools = null; 
        private ConnectorEPN connectorEPN = null;

        public ManagerData()
        {
            sqlCommandTools = new SqlCommandTools();
            connectorEPN = new ConnectorEPN();
        }

        public async Task StartService()
        {
            List<Categorie> categories = connectorEPN.GetCategories();
            foreach(Categorie categorie in categories)
            {
                Task.Run(() => WorkShiping(categorie));
            }
        }

        private void WorkShiping(Categorie categorie)
        {
            int backCountOrder = 0;
            List<Offer> offers = new List<Offer>();
            int offset = 0;
            int totalFound = 0;
            List<Offer> offers1 = connectorEPN.GetOffers(categorie.id, ref totalFound, offset);
            if(offers1.Count != 0)
            {
                offers.AddRange(offers1);
            }
            while(offers1.Count != 0)
            {
                offset += 1000;
                offers1 = connectorEPN.GetOffers(categorie.id, ref totalFound, offset);
                if (offers1.Count == backCountOrder)
                {
                    Task.Run(() => SetOffers(offers));
                    offers = null;
                    break;
                }
                offers.AddRange(offers1);
                backCountOrder = offers1.Count;
            }
        }

        private void SetOffers(List<Offer> offers)
        {
            OfferOrder offerOrder = null;
            PriceOffer priceOffer = null;
            foreach (Offer offer in  offers)
            {
                if(sqlCommandTools.CheckOffer(offer.id))
                {
                    if(sqlCommandTools.CheckPrice(offer.id))
                    {
                        priceOffer = new PriceOffer();
                        priceOffer.DatateUpdate = DateTime.Now.ToString();
                        priceOffer.Price = offer.price;
                        sqlCommandTools.AddPrice(offer.id, priceOffer);
                    }
                }
                else
                {
                    offerOrder = new OfferOrder();
                    priceOffer = new PriceOffer();
                    priceOffer.DatateUpdate = DateTime.Now.ToString();
                    priceOffer.Price = offer.price;
                    offerOrder.Id = offer.id;
                    offerOrder.Description = offer.description;
                    offerOrder.Id_category = offer.id_category;
                    offerOrder.Name = offer.name;
                    offerOrder.Store_id = offer.store_id;
                    offerOrder.PriceOffers = new List<PriceOffer>();
                    offerOrder.PriceOffers.Add(priceOffer);
                    sqlCommandTools.AddOffer(offerOrder);
                }
            }
        }
    }
}
