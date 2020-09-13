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

        [Route("api/Products/GetByCategory/{category}/{seller}")]
        public IEnumerable<Product> GetByCategory(string category, string seller)
        {
            if (category.Equals("All") && seller.Equals("All"))
            {
                return db.Products.ToList();
            }
            else if (category.Equals("All") && !seller.Equals("All"))
            {
                return db.Products.Where(m => m.Seller.Name.Equals(seller)).ToList();
            }
            else if (!category.Equals("All") && seller.Equals("All"))
            {
                return db.Products.Where(m => m.Category.ToString().Equals(category)).ToList();
            }
            else
                return db.Products.Where(p => p.Seller.Name.Equals(seller)).Where(m => m.Category.ToString().Equals(category)).ToList();
        }
        [Route("api/Products/GetBySearch/{searchString}/{category}/{seller}")]
        public IEnumerable<Product> GetBySearch(string searchString, string category, string seller)
        {
            if (category.Equals("All") && seller.Equals("All"))
            {
                return db.Products.Where(m => m.Name.ToLower().Contains(searchString)).ToList();
            }
            else if (category.Equals("All") && !seller.Equals("All"))
            {
                return db.Products.Where(m => m.Name.ToLower().Contains(searchString)).Where(m => m.Seller.Name.Equals(seller)).ToList();
            }
            else if (!category.Equals("All") && seller.Equals("All"))
            {
                return db.Products.Where(m => m.Name.ToLower().Contains(searchString)).Where(m => m.Category.ToString().Equals(category)).ToList();
            }
            else
                return db.Products.Where(m => m.Name.ToLower().Contains(searchString)).Where(p => p.Seller.Name.Equals(seller)).Where(m => m.Category.ToString().Equals(category)).ToList();
        }

        [Route("api/Products/Delete/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }
    }
}
