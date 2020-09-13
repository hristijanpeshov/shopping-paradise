using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITPROEKT.Models;

namespace ITPROEKT.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.sellers = db.Sellers;
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            Order order = new Order();
            order.Quantity = Int32.Parse(Request["Quantity"].ToString());
            order.Color = Request["color"].ToString();
            order.ProductId = id;
            order.Product = db.Products.Find(id);
            string req = Request["price"];
            order.Product.Price = float.Parse(req.ToString());
            order.TotalAmount = order.Quantity * order.Product.Price;
            order.Status = "In cart";
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Order>();
            }
            List<Order> orders = (List<Order>)Session["cart"];
            orders.Add(order);
            return RedirectToAction("Index", "Products");
            /*db.Orders.Add(order);
            db.SaveChanges();*/
        }
        [AllowAnonymous]
        public ActionResult DailyDealDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            product.Price *= 0.5F;
            return View("Details", product);
        }
        [AllowAnonymous]
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Name,URL,Description,SellerId,Price,Rating")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "Name", product.SellerId);
            return View(product);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "Name", product.SellerId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Name,URL,Description,SellerId,Price,Rating")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "Name", product.SellerId);
            return View(product);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public ActionResult DailyDeal()
        {
            var product = GetDailyDeal();
            return PartialView("_DailyDeal", product);
        }

        private Product GetDailyDeal()
        {
            var product = db.Products.Include(p => p.Seller).OrderBy(p => System.Guid.NewGuid()).First();
            product.Price *= 0.5F;
            return product;
        }

    }
}
