using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MediaBay.Models;

namespace MediaBay.Migrations
{
    [DbContext(typeof(MediaBayContext))]
    [Migration("20160621191518_groupTable")]
    partial class groupTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MediaBay.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("PromoCode");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("GroupId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("MediaBay.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdminId");

                    b.Property<double?>("Bytes");

                    b.Property<string>("Description");

                    b.Property<int?>("GroupId");

                    b.Property<int?>("MediaTypeId");

                    b.Property<double?>("Milliseconds");

                    b.Property<string>("Name");

                    b.Property<int?>("SeriesId");

                    b.Property<decimal?>("UnitPrice");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MediaBay.Models.Series", b =>
                {
                    b.Property<int>("SeriesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("SeriesId");

                    b.ToTable("Series");
                });
        }
    }
}
