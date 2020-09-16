using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITPROEKT.Models
{
    public class FinalOrder
    {
        public int Id { get; set; }
        public string IdentityUser { get; set; }
        public DateTime Info { get; set; }
        public List<Order> Orders { get; set; }
        public float TotalAmount { get; set; }


    }
}