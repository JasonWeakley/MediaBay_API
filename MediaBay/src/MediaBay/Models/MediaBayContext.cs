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
        // The name of the DbSet is what the migration uses to name the DB tables

        //public DbSet<AdminUser> AdminUser { get; set; }
        //public DbSet<Customer> Customer { get; set; }
        public DbSet<Group> Group { get; set; }
        //public DbSet<Invoice> Invoice { get; set; }
        //public DbSet<InvoiceLine> InvoiceLine { get; set; }
        //public DbSet<MediaType> MediaType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Series> Series { get; set; }
    }
}
