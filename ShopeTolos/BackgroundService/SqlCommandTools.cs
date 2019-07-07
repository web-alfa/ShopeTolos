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

        public bool CheckOffer(string idOffer)
        {
            return context.OfferOrders.FirstOrDefault(o => o.Id == idOffer) != null;
        }

        public bool CheckPrice(string idOffer)
        {
            bool isDataUpdate = false;
            OfferOrder offerOrder = context.OfferOrders.Include(o => o.PriceOffers).First(o => o.Id == idOffer);
            if(offerOrder.PriceOffers != null && offerOrder.PriceOffers.Count != 0)
            {
                string priceOfferDatateUpdate = offerOrder.PriceOffers.Last().DatateUpdate;
                if(DateTime.Parse(GetDFormat(priceOfferDatateUpdate)) > DateTime.Now.AddHours(2))
                {
                    isDataUpdate = true;
                }
            }
            return isDataUpdate;
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

        public async Task AddOffer(OfferOrder offerOrder)
        {
            context.OfferOrders.Add(offerOrder);
            await context.SaveChangesAsync();
        }

        public List<OfferOrder> GetOfferOrders()
        {
            return context.OfferOrders.ToList();
        }

        public bool CheckUpdateShope(int idShope)
        {
            bool isDataUpdate = false;
            Store store = context.Stores.FirstOrDefault(o => o.ID == idShope);
            if (store != null)
            {
                string stroreDatateUpdate = store.DateUpdate;
                if (DateTime.Parse(GetDFormat(stroreDatateUpdate)) > DateTime.Now.AddHours(2))
                {
                    isDataUpdate = true;
                }
            }
            return isDataUpdate;
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