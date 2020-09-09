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
        [Route("api/Products/GetProducts/{offset}")]
        public IEnumerable<Product> GetProducts(int offset) {            
            return db.Products.OrderBy(m => m.Id).Skip(offset).Take(9).ToList();
        }

    }
}
