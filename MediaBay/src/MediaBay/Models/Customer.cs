using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Company { get; set; }
        public int Phone { get; set; }
        public int SupportRepId { get; set; } // nullable

        ICollection<Invoice> MyInvoices { get; set; }
    }
}
