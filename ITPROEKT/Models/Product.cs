using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public enum ProductCategory
    {
        Technology,
        Clothes,
        MakeUp
    }
    public class Product
    {
        public ProductCategory Category { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public String URL { get; set; }
        public String Description { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public float Price { get; set; }
        public float Rating { get; set; }
        public int InStock { get; set; }

    }
}