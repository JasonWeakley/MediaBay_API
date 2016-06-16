using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaBay.Models
{
    public class AdminUser
    {
        public int AdminId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Title { get; set; }
        public int ReportsTo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        ICollection<Product> CreatedProducts { get; set; }
    }
}
