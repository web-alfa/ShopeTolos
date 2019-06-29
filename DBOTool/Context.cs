using DBOTool.Model;
using Microsoft.EntityFrameworkCore;

namespace DBOTool
{
    public class Context : DbContext
    {
        public DbSet<PriceOffer> priceOffers { get; set; }
        public DbSet<OfferOrder> OfferOrders { get; set; }

        public Context()
        {
            //Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToolShope;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=WebTaxi;Integrated Security=False;User ID=123;Password=123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            }
        }
    }
}