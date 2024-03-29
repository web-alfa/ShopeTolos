﻿using DBOTool.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace DBOTool
{
    public class Context : DbContext
    {
        public DbSet<PriceOffer> priceOffers { get; set; }
        public DbSet<OfferOrder> OfferOrders { get; set; }
        public DbSet<Store> Stores { get; set; }

        public Context()
        {
            try
            {
                Database.Migrate();
                //Database.EnsureCreated();
            }
            catch (Exception e)
            {
                File.WriteAllText("1.txt", e.Message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ToolShope;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Data Source=185.204.0.238;Initial Catalog=ShopeTool;Integrated Security=False;User ID=Roma;Password=123;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            }
        }
    }
}