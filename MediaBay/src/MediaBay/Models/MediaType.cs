using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class MediaType
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        ICollection<Product> ProductsOfMediaType { get; set; }
    }
}
