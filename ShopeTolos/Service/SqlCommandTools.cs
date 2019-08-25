using DBOTool;
using DBOTool.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopeTolos.BackgroundService
{
    public class SqlCommandTools
    {
        private Context context = null;

        public SqlCommandTools()
        {
            context = new Context();
        }

        public List<OfferOrder> GetShiping()
        {
            return context.OfferOrders.ToList();
        }

        public List<Store> GetStore()
        {
            return context.Stores.ToList();
        }

        public async Task<List<OfferOrder>> GetOfferOrders()
        {
            return await context.OfferOrders.Include(o => o.PriceOffers).ToListAsync();
        }

        public bool CheckOffer(string idOffer)
        {
            return context.OfferOrders.FirstOrDefault(o => o.Id == idOffer) != null;
        }

        public bool CheckPrice(string idOffer)
        {
            bool isDataUpdate = false;
            using (var c = new Context())
            {
                OfferOrder offerOrder = c.OfferOrders.Include(o => o.PriceOffers).First(o => o.Id == idOffer);
                if (offerOrder.PriceOffers != null && offerOrder.PriceOffers.Count != 0)
                {
                    string priceOfferDatateUpdate = offerOrder.PriceOffers.Last().DatateUpdate;
                    DateTime dateTime = DateTime.Parse($"{GetDFormat(priceOfferDatateUpdate.Remove(priceOfferDatateUpdate.IndexOf(" ")))} {priceOfferDatateUpdate.Remove(0, priceOfferDatateUpdate.IndexOf(" ") + 1)}");
                    if (dateTime < DateTime.Now.AddHours(-3))
                    {
                        isDataUpdate = true;
                    }
                }
            }
            return isDataUpdate;
        }

        internal OfferOrder GetOfferOrder(string idShiping)
        {
            return context.OfferOrders.Include(o => o.PriceOffers).FirstOrDefault(o => o.Id == idShiping);
        }

        public async void UpdateShiping(OfferOrder offerOrder)
        {
            context.OfferOrders.Update(offerOrder);
            await context.SaveChangesAsync();
        }

        public async void AddPrice(string idOffer, PriceOffer priceOffer)
        {
            OfferOrder offerOrder = context.OfferOrders.Include(o => o.PriceOffers).First(o => o.Id == idOffer);
            if(offerOrder.PriceOffers == null)
            {
                offerOrder.PriceOffers = new List<PriceOffer>();
            }
            offerOrder.PriceOffers.Add(priceOffer);
            await context.SaveChangesAsync();
        }

        public async void AddOffer(OfferOrder offerOrder)
        {
            context.OfferOrders.Add(offerOrder);
            await context.SaveChangesAsync();
        }

        public bool CheckUpdateShope(int idShope)
        {
            bool isDataUpdate = false;
            Store store = context.Stores.FirstOrDefault(o => o.IDShope == idShope);
            if (store != null)
            {
                if (store.DateUpdate != null)
                {
                    string stroreDatateUpdate = store.DateUpdate;
                    DateTime dateTime = DateTime.Parse($"{GetDFormat(stroreDatateUpdate.Remove(stroreDatateUpdate.IndexOf(" ")))} {stroreDatateUpdate.Remove(0, stroreDatateUpdate.IndexOf(" ") + 1)}");
                    if (dateTime < DateTime.Now.AddHours(-3))
                    {
                        isDataUpdate = true;
                    }
                }
                else
                {
                    isDataUpdate = true;
                }
            }
            return isDataUpdate;
        }

        internal Store GetOneStore(string idShope)
        {
            return context.Stores.FirstOrDefault(s => s.IDShope.ToString() == idShope);
        }

        public async void AddStore(Store store)
        {
            context.Stores.Add(store);
            await context.SaveChangesAsync();
        }

        public async void UpdateStore(Store store)
        {
            context.Stores.Update(store);
            await context.SaveChangesAsync();
        }

        public bool CheckShope(int idShope)
        {
            bool isShope = false;
            Store store = context.Stores.FirstOrDefault(o => o.IDShope == idShope);
            if (store != null)
            {
                isShope = true;
            }
            return isShope;
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