using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class Series
    {
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        ICollection<Product> ProductsInSeries { get; set; }
    }
}
