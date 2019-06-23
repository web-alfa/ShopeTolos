using ShopeTolos.BackgroundService.WorkData.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopeTolos.BackgroundService.WorkData
{
    public class ManagerData
    {
        private ConnectorEPN connectorEPN = null;
        private List<Offer> offers = new List<Offer>();

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
            int offset = 0;
            int totalFound = 0;
            List<Offer> offers1 = connectorEPN.GetOffers(categorie.id, ref totalFound, offset);
            while(totalFound != 0)
            {
                offers1 = connectorEPN.GetOffers(categorie.id, ref totalFound, offset);
                offers.AddRange(offers1);
                offset += 1000;
            }
        }
    }
}
