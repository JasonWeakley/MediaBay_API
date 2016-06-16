using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class MediaBayContext : DbContext
    {
        public MediaBayContext(DbContextOptions<MediaBayContext> options)
            : base(options)
        { }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Group> ProductGroups { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Series> ProductSeries { get; set; }
    }
}
