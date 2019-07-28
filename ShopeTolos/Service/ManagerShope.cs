using DBOTool.Model;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using ShopeTolos.BackgroundService;
using ShopeTolos.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Response> GetStatistics(string idShope, string idShiping)
        {
            ResponseOrder responseOrder = null;
            ResponseStore responseStore = null;
            Response response = new Response();
            OfferOrder offerOrder1 = await GetOfferOrder(idShiping, idShope);
            Store store = await GetStore(idShope);
            if (offerOrder1 != null)
            {
                responseOrder = new ResponseOrder();
                DateTime dateTime = DateTime.Parse(offerOrder1.PriceOffers.First().DatateUpdate);
                if (dateTime.AddMonths(1) <= DateTime.Now)
                {
                    responseOrder.PriceOffers = offerOrder1.PriceOffers;
                    responseOrder.Status = "OK";
                }
                else
                {
                    responseOrder.PriceOffers = new List<PriceOffer>();
                    responseOrder.Status = "No_Content";
                }
            }
            else
            {
                responseOrder = new ResponseOrder();
                responseOrder.PriceOffers = new List<PriceOffer>();
                responseOrder.Status = "No_Content";
            }
            if(store != null)
            {
                responseStore = new ResponseStore();
                responseStore.Status = "OK";
            }
            else
            {
                responseStore = new ResponseStore();
                responseStore.Status = "No_Content";
            }
            response.ResponseOrder = responseOrder;
            return response;
        }

        private async Task<OfferOrder> GetOfferOrder(string idShiping, string idShope)
        {
            OfferOrder offerOrder1 = null;
            if (sqlCommandTools.CheckOffer(idShiping))
            {
                offerOrder1 = sqlCommandTools.GetOfferOrder(idShiping);
            }
            else
            {
                OfferOrder offerOrder = new OfferOrder();
                PriceOffer priceOffer = new PriceOffer();
                priceOffer.DatateUpdate = DateTime.Now.ToString();
                offerOrder.Id = idShiping;
                offerOrder.Name = "New";
                offerOrder.Store_id = Convert.ToInt32(idShope); 
                offerOrder.PriceOffers = new List<PriceOffer>();
                offerOrder.PriceOffers.Add(priceOffer);
                await sqlCommandTools.AddOffer(offerOrder);
            }
            return offerOrder1;
        }

        private async Task<Store> GetStore(string idShope)
        {
            Store store = null;
            if (sqlCommandTools.CheckShope(Convert.ToInt32(idShope)))
            {
                store = sqlCommandTools.GetOneStore(idShope);
            }
            return store;
        }

        private string Translete(string text, string language)
        {
            TranslationClient client = TranslationClient.Create(GoogleCredential.FromFile("ShopeTools-e74c814eef6c.json"));
            var response = client.TranslateText(text, language);
            return response.TranslatedText;
        }

        private string GetDFormat(string data)
        {
            DateTime date;
            if (DateTime.TryParseExact(data, "MM.dd.yyyy", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "dd.MM.yyyy", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "yyyy.MM.dd", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "MM-dd-yyyy", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "dd-MM-yyyy", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "yyyy-MM-dd", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "MM/dd/yyyy", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "dd/MM/yyyy", null, DateTimeStyles.None, out date))
            {
            }
            else if (DateTime.TryParseExact(data, "yyyy/MM/dd", null, DateTimeStyles.None, out date))
            {
            }
            return date.ToShortDateString();
        }
    }
}