using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class Cart
    {
        public List<Product> productsInCart { get; set; }

        public Cart()
        {
            productsInCart = new List<Product>();
        }
    }
}