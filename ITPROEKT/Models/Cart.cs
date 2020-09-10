using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class Cart
    {
        Dictionary<Product, int> productsInCart;

        public Cart()
        {
            productsInCart = new Dictionary<Product, int>();
        }
    }
}