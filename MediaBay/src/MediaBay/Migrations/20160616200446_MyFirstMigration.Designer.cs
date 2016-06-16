using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MediaBay.Models;

namespace MediaBay.Migrations
{
    [DbContext(typeof(MediaBayContext))]
    [Migration("20160616200446_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediaBay.Models.AdminUser", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<string>("Password");

                    b.Property<int>("ReportsTo");

                    b.Property<string>("Title");

                    b.Property<string>("Username");

                    b.HasKey("AdminId");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("MediaBay.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("FName");

                    b.Property<string>("LName");

                    b.Property<int>("Phone");

                    b.Property<int>("SupportRepId");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MediaBay.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("PromoCode");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("GroupId");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("MediaBay.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillAddress");

                    b.Property<string>("BillCity");

                    b.Property<string>("BillCountry");

                    b.Property<string>("BillPostalCode");

                    b.Property<string>("BillState");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<decimal>("Total");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MediaBay.Models.InvoiceLine", b =>
                {
                    b.Property<int>("InvoiceLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InvoiceId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("InvoiceLineId");

                    b.ToTable("InvoiceLines");
                });

            modelBuilder.Entity("MediaBay.Models.MediaType", b =>
                {
                    b.Property<int>("MediaTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("MediaBay.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminId");

                    b.Property<double>("Bytes");

                    b.Property<string>("Description");

                    b.Property<int>("GroupId");

                    b.Property<int>("MediaTypeId");

                    b.Property<double>("Milliseconds");

                    b.Property<string>("Name");

                    b.Property<int>("SeriesId");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MediaBay.Models.Series", b =>
                {
                    b.Property<int>("SeriesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("SeriesId");

                    b.ToTable("ProductSeries");
                });
        }
    }
}
