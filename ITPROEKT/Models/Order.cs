using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Status { get; set; }
        public float TotalAmount { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public ProductInfo productInfo { get; set; }

        public Order()
        {
            productInfo = new ProductInfo();
        }

        public override string ToString()
        {
            string result = "";
            result += "Order id: " + Id + "\n";
            result += "Status: " + Status + "\n";
            result += "Color:" + Color + "\n";
            result += "Quantity: " + Quantity + "\n";
            result += "Total amount: " + TotalAmount + "\n";
            return result;
        }

    }
}