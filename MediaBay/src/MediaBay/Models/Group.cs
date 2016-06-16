using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public Decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string PromoCode { get; set; }

        ICollection<Product> ProductsInGroup { get; set; }
    }
}
