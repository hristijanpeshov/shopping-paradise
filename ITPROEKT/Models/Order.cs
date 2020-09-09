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
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}