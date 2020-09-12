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
    public class ToDeliverOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToDeliverOrders
        public ActionResult Index()
        {
            var toDeliverOrders = db.ToDeliverOrders.Include(t => t.Product);
            return View(toDeliverOrders.ToList());
        }

        public ActionResult Buy()
        {

            foreach (var item in (List<Order>)Session["cart"])
            {
                ToDeliverOrder FinalOrder = new ToDeliverOrder(db);
                FinalOrder.IdentityUser = "asd";
                FinalOrder.Info = DateTime.Now;
                FinalOrder.Color = item.Color;
                FinalOrder.ProductId = 12;
                FinalOrder.Product = item.Product;
                FinalOrder.Quantity = item.Quantity;
                FinalOrder.TotalAmount = item.TotalAmount;
                FinalOrder.Status = "Delivering";
                db.ToDeliverOrders.Add(FinalOrder);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Products");
        }

        /* // GET: ToDeliverOrders/Details/5
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             ToDeliverOrder toDeliverOrder = db.ToDeliverOrders.Find(id);
             if (toDeliverOrder == null)
             {
                 return HttpNotFound();
             }
             return View(toDeliverOrder);
         }

         // GET: ToDeliverOrders/Create
         public ActionResult Create()
         {
             ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
             return View();
         }

         // POST: ToDeliverOrders/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "Id,IdentityUser,Info,Status,TotalAmount,Quantity,Color,ProductId")] ToDeliverOrder toDeliverOrder)
         {
             if (ModelState.IsValid)
             {
                 db.ToDeliverOrders.Add(toDeliverOrder);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", toDeliverOrder.ProductId);
             return View(toDeliverOrder);
         }

         // GET: ToDeliverOrders/Edit/5
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             ToDeliverOrder toDeliverOrder = db.ToDeliverOrders.Find(id);
             if (toDeliverOrder == null)
             {
                 return HttpNotFound();
             }
             ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", toDeliverOrder.ProductId);
             return View(toDeliverOrder);
         }

         // POST: ToDeliverOrders/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "Id,IdentityUser,Info,Status,TotalAmount,Quantity,Color,ProductId")] ToDeliverOrder toDeliverOrder)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(toDeliverOrder).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", toDeliverOrder.ProductId);
             return View(toDeliverOrder);
         }

         // GET: ToDeliverOrders/Delete/5
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             ToDeliverOrder toDeliverOrder = db.ToDeliverOrders.Find(id);
             if (toDeliverOrder == null)
             {
                 return HttpNotFound();
             }
             return View(toDeliverOrder);
         }

         // POST: ToDeliverOrders/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             ToDeliverOrder toDeliverOrder = db.ToDeliverOrders.Find(id);
             db.ToDeliverOrders.Remove(toDeliverOrder);
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
         }*/
    }
}
