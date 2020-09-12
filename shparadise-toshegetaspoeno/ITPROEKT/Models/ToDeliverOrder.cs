using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class ToDeliverOrder
    {
        public int Id { get; set; }
        public string IdentityUser { get; set; }
        public DateTime Info { get; set; }
        public string Status { get; set; }
        public float TotalAmount { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public ToDeliverOrder(ApplicationDbContext context)
        {
            context = new ApplicationDbContext();
        }
    }
}