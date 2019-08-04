﻿// <auto-generated />
using DBOTool;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBOTool.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBOTool.Model.OfferOrder", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Id_category");

                    b.Property<string>("Name");

                    b.Property<int>("Store_id");

                    b.HasKey("Id");

                    b.ToTable("OfferOrders");
                });

            modelBuilder.Entity("DBOTool.Model.PriceOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DatateUpdate");

                    b.Property<string>("OfferOrderId");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("OfferOrderId");

                    b.ToTable("priceOffers");
                });

            modelBuilder.Entity("DBOTool.Model.Store", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Communication");

                    b.Property<string>("DateUpdate");

                    b.Property<int>("IDShope");

                    b.Property<bool>("IsTopShope");

                    b.Property<bool>("IsUodateToDay");

                    b.Property<string>("ItemAsDescribed");

                    b.Property<string>("Name");

                    b.Property<string>("Negative1_2Stars");

                    b.Property<string>("Neutral3Stars");

                    b.Property<string>("Positive4_5Stars");

                    b.Property<string>("ShippingSpeed");

                    b.Property<string>("StartOfSales");

                    b.HasKey("ID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("DBOTool.Model.PriceOffer", b =>
                {
                    b.HasOne("DBOTool.Model.OfferOrder")
                        .WithMany("PriceOffers")
                        .HasForeignKey("OfferOrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
