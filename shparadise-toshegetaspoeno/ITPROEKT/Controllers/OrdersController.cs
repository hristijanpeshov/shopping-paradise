using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITPROEKT.Models;
using Microsoft.AspNet.Identity;

namespace ITPROEKT.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            List<FinalOrder> finals = db.FinalOrders.Include(m=> m.Orders).ToList();
            return View(finals);
        }

        public ActionResult Checkout()
        {
            List<Order> finals = (List<Order>)Session["cart"];
            return View(finals);
        }

        public ActionResult DeleteItem(int id)
        {
            List<Order> orders = (List<Order>)Session["cart"];
            orders.RemoveAt(id);
            Session["cart"] = orders;
            return RedirectToAction("Checkout");
        }

        public ActionResult DeleteWholeCart()
        {
            Session["cart"] = null;
            return RedirectToAction("Checkout");
        }
        [Authorize]
        public ActionResult Buy()
        {
            List<Order> orders = (List<Order>)Session["cart"];
            FinalOrder finalOrder = new FinalOrder();
            finalOrder.Orders = new List<Order>();
            finalOrder.Orders = orders;
            finalOrder.Info = DateTime.Now;
            float sum = 0F;
            finalOrder.IdentityUser = User.Identity.GetUserId();
            foreach (var item in orders)
            {
                sum += item.TotalAmount;
            }
            finalOrder.TotalAmount = sum;
            string id = User.Identity.GetUserId();
            ApplicationUser user = db.Users.Find(id);
            user.sumPaid += sum;
            db.FinalOrders.Add(finalOrder);
            db.SaveChanges();
            Session["cart"] = null;
            if (user.sumPaid > 1500 && !User.IsInRole("ClubUser"))
            {
                return RedirectToAction("AddClubMember", "Account", new { idd = id });
            }
            else return RedirectToAction("Index", "Products");
        }

       

        
        



        // GET: Orders/Details/5
        /*  public ActionResult Details(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Order order = db.Orders.Find(id);
              if (order == null)
              {
                  return HttpNotFound();
              }
              return View(order);
          }

          // GET: Orders/Create
          public ActionResult Create()
          {
              ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
              return View();
          }

          // POST: Orders/Create
          // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "Id,UserID,Status,TotalAmount,Quantity,ProductId")] Order order)
          {
              if (ModelState.IsValid)
              {
                  db.Orders.Add(order);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

              ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", order.ProductId);
              return View(order);
          }

          // GET: Orders/Edit/5
          public ActionResult Edit(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Order order = db.Orders.Find(id);
              if (order == null)
              {
                  return HttpNotFound();
              }
              ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", order.ProductId);
              return View(order);
          }

          // POST: Orders/Edit/5
          // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit([Bind(Include = "Id,UserID,Status,TotalAmount,Quantity,ProductId")] Order order)
          {
              if (ModelState.IsValid)
              {
                  db.Entry(order).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", order.ProductId);
              return View(order);
          }

          // GET: Orders/Delete/5
          public ActionResult Delete(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              Order order = db.Orders.Find(id);
              if (order == null)
              {
                  return HttpNotFound();
              }
              return View(order);
          }

          // POST: Orders/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(int id)
          {
              Order order = db.Orders.Find(id);
              db.Orders.Remove(order);
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
