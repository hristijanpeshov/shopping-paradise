using ITPROEKT.Models;
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
       
        [Route("api/Products/GetByCategory/{category}")]
        public IEnumerable<Product> GetByCategory(string category)
        {
            if (category.Equals("All"))
            {
                return db.Products.ToList();
            }
            return db.Products.Where(m => m.Category.ToString().Equals(category)).ToList();
        }
    }
}
