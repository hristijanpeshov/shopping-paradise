﻿using ITPROEKT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;

namespace ITPROEKT.Controllers.api
{
    public class ProductsController : ApiController
    {

        ApplicationDbContext db = new ApplicationDbContext();
       
        [Route("api/Products/GetByCategory/{category}/{seller}")]
        public IEnumerable<Product> GetByCategory(string category, string seller)
        {
            if (category.Equals("All") && seller.Equals("All"))
            {
                return db.Products.ToList();
            }
            else if(category.Equals("All") && !seller.Equals("All"))
            {
                return db.Products.Where(m => m.Seller.Name.Equals(seller)).ToList();
            }
            else if(!category.Equals("All") && seller.Equals("All"))
            {
                return db.Products.Where(m => m.Category.ToString().Equals(category)).ToList();
            }
            else
                return db.Products.Where(p => p.Seller.Name.Equals(seller)).Where(m => m.Category.ToString().Equals(category)).ToList();
        }
    }
}