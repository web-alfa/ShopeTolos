﻿using DBOTool.Model;
using ShopeTolos.BackgroundService.WorkData.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
            foreach (Categorie categorie in categories)
            {
                WorkShiping(categorie);
            }
        }

        private async void WorkShiping(Categorie categorie)
        {
            string backIdOrder = "";
            List<Offer> offers = new List<Offer>();
            int offset = 0;
            int totalFound = 0;
            try
            {
                List<Offer> offers1 = connectorEPN.GetOffers(categorie.id, ref totalFound, offset);
                if (offers1.Count != 0)
                {
                    offers.AddRange(offers1);
                }
                while (offers1.Count != 0)
                {
                    offset += 1000;
                    if (offers1.Count >= 900)
                    {
                        offers1 = connectorEPN.GetOffers(categorie.id, ref totalFound, offset);
                    }
                    else
                    {
                        offers1 = null;
                    }
                    if (offers1 == null || offers1.Count == 0 || offers1[0].id == backIdOrder)
                    {
                        await SetOffers(offers);
                        offers = null;
                        backIdOrder = "";
                        break;
                    }
                    offers.AddRange(offers1);
                    backIdOrder = offers1[0].id;
                }
            }
            catch (Exception e)
            {
                File.AppendAllText("log/WorkShiping.txt", $"{e.Message} {Environment.NewLine}");
            }
        }

        private async Task SetOffers(List<Offer> offers)
        {
            foreach (Offer offer in offers)
            {
                OfferOrder offerOrder = null;
                PriceOffer priceOffer = null;
                try
                {
                    if (!sqlCommandTools.CheckOffer(offer.id))
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
                catch (Exception e)
                {
                    File.AppendAllText("log/SetOffers.txt", $"{e.Message} {Environment.NewLine}");
                }
            }
        }
    }
}