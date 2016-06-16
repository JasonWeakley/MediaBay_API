using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class InvoiceLine
    {
        [Key]
        public int InvoiceLineId { get; set; }
        public int Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
    }
}
