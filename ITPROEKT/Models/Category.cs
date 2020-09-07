using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public virtual List<Product> products { get; set; }
        public String Name { get; set; }

        public Category()
        {
            products = new List<Product>();
        }
    }
}