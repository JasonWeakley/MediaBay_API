using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int MediaTypeId { get; set; }
        public int SeriesId { get; set; }
        public int GroupId { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; }
        public double Milliseconds { get; set; }
        public double Bytes { get; set; }
        public Decimal UnitPrice { get; set; }
        public string Description { get; set; }
    }
}
