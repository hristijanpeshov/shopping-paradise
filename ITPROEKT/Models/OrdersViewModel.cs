using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class OrdersViewModel
    {
        public DateTime Info { get; set; }
        public List<Order> ProductsInCart { get; set; }
        public float TotalAmount { get; set; }

        public OrdersViewModel()
        {
            ProductsInCart = new List<Order>();
        }
    }
}