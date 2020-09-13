using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public string URL { get; set; }
        public string Country { get; set; }
        public string Vision { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}