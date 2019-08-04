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
                double timeOnTheMarketYears = 0;
                responseStore.CommunicationS = Convert.ToInt32(store.Communication.Replace("%", ""));
                responseStore.ShippingSpeedS = Convert.ToInt32(store.ShippingSpeed.Replace("%", ""));
                responseStore.ItemAsDescribedS = Convert.ToInt32(store.ItemAsDescribed.Replace("%", ""));
                responseStore.StartOfSaleS = GetPercentStartOfSale(store.StartOfSales, ref timeOnTheMarketYears);
                responseStore.FeedBackS = GetPercentFeedBack(Convert.ToInt32(store.Positive4_5Stars.Replace(",", "").Trim()), Convert.ToInt32(store.Neutral3Stars.Replace(",", "").Trim()), Convert.ToInt32(store.Negative1_2Stars.Replace(",", "").Trim()));
                responseStore.timeOnTheMarketYears = timeOnTheMarketYears.ToString();
                responseStore.Communication = GetDescCommunication(responseStore.CommunicationS);
                responseStore.ShippingSpeed = GetShippingSpeed(responseStore.ShippingSpeedS);
                responseStore.ItemAsDescribed = GetDescItemAsDescribed(responseStore.ItemAsDescribedS);
                responseStore.StartOfSale = GetDescStartOfSale(timeOnTheMarketYears);
                responseStore.FeedBack = GetDescFeedBack(responseStore.FeedBackS);
                responseStore.Status = "OK";
            }
            else
            {
                responseStore = new ResponseStore();
                responseStore.Status = "No_Content";
            }
            response.ResponseOrder = responseOrder;
            response.ResponseStore = responseStore;
            return response;
        }

        private string GetDescFeedBack(int precent)
        {
            string desc = null;
            if (precent < 33)
            {
                desc = $"Большая часть покупателей товаров этого продавца, не довольна товаром, {100 - precent}% покупателей не довольна товаром";
            }
            else if (precent >= 33 && 66 >= precent)
            {
                desc = $"половина покупателей товаров этого продавца, не довольна товаром , {100 - precent}% покупателей не довольна товаром";
            }
            else if (66 < precent)
            {
                 desc = $"Большая часть покупателей товаров этого продавца, довольна товаром, {100 - precent}% покупателей не довольна товаром";
            }
            return desc;
        }

        private string GetDescStartOfSale(double timeOnTheMarketYears)
        {
            string desc = null;
            if (timeOnTheMarketYears < 1)
            {
                desc = "Продавец на площадке менее года";
            }
            else if (timeOnTheMarketYears == 1)
            {
                desc = "Продавец на площадке один год";
            }
            else if (timeOnTheMarketYears > 1 && 2 > timeOnTheMarketYears)
            {
                desc = "Продавец на площадке более одного года";
            }
            else if (2 == timeOnTheMarketYears)
            {
                desc = "Продавец на площадке два года";
            }
            else if (timeOnTheMarketYears > 2 && 3 > timeOnTheMarketYears)
            {
                desc = "Продавец на площадке более двух лет";
            }
            else if (3 == timeOnTheMarketYears)
            {
                desc = "Продавец на площадке три года";
            }
            else if (timeOnTheMarketYears > 3 && 4 > timeOnTheMarketYears)
            {
                desc = "Продавец на площадке более трех лет";
            }
            else if (4 == timeOnTheMarketYears)
            {
                desc = "Продавец на площадке четыре года";
            }
            else if (timeOnTheMarketYears > 4 && 5 > timeOnTheMarketYears)
            {
                desc = "Продавец на площадке более четырех лет";
            }
            else if (5 == timeOnTheMarketYears)
            {
                desc = "Продавец на площадке пять лет";
            }
            else if (5 < timeOnTheMarketYears)
            {
                desc = "Продавец на площадке более пяти лет";
            }
            return desc;
        }

        private string GetDescItemAsDescribed(int precent)
        {
            string desc = null;
            if (precent < 33)
            {
                desc = "Товары продавца соответствубт описанию";
            }
            else if (precent >= 33 && 66 >= precent)
            {
                desc = "не все товары продавца соответствубт описанию";
            }
            else if (66 < precent)
            {
                desc = "Товары продавца не соответствубт описанию";
            }
            return desc;
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

        private string GetDescCommunication(int precent)
        {
            string desc = null;
            if(precent < 33)
            {
                desc = "У продавца плохая стастика общения с покупателем";
            }
            else if (precent >= 33 && 66 >= precent)
            {
                desc = "У продавца средняя стастика общения с покупателем";
            }
            else if (66 < precent)
            {
                desc = "У продавца хорошая стастика общения с покупателем";
            }
            return desc;
        }

        private string GetShippingSpeed(int precent)
        {
            string desc = null;
            if (precent < 33)
            {
                desc = "У продавца плохая стастика времени доставки товара";
            }
            else if (precent >= 33 && 66 >= precent)
            {
                desc = "У продавца средняя стастика времени доставки товара";
            }
            else if (66 < precent)
            {
                desc = "У продавца хорошая стастика времени доставки товара";
            }
            return desc;
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

        private int GetPercentStartOfSale(string StartOfSale, ref double timeOnTheMarketYears)
        {
            int percentStartOfSale = 0;
            DateTime startOfSaleDate = DateTime.Parse(StartOfSale);
            int timeOnTheMarketDays = (int)(DateTime.Now.Date  - startOfSaleDate.Date).TotalDays;
            timeOnTheMarketYears = timeOnTheMarketDays / 365.25;
            percentStartOfSale = (timeOnTheMarketDays * 100) / 1826;
            return percentStartOfSale;
        }

        private int GetPercentFeedBack(int positiveFB, int neutralFB, int negativeFB)
        {
            int percentFeedBack = 0;
            int countFB = positiveFB + neutralFB + negativeFB;
            percentFeedBack = (positiveFB * 100) / countFB;
            return percentFeedBack;
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
            else if (DateTime.TryParseExact(data, "dd-MMM-yyyy", null, DateTimeStyles.None, out date))
            {
            }
            return date.ToShortDateString();
        }
    }
}