using ShopeTolos.BackgroundService.WorkData.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class ManagerData
    {
        private ConnectorEPN connectorEPN = null;

        public ManagerData()
        {
            connectorEPN = new ConnectorEPN();
        }

        public async Task StartService()
        {
            List<Categorie> categories = connectorEPN.GetCategories();
            foreach(Categorie categorie in categories)
            {
                WorkShiping(categorie);
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
                    offers = null;
                    break;
                }
                offers.AddRange(offers1);
                backCountOrder = offers1.Count;
            }
        }
    }
}
