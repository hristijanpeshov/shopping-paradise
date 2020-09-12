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
            List<FinalOrder> finals =  db.FinalOrders.ToList();
            return View(finals);
        }

        public ActionResult Checkout()
        {
            List<Order> orders = (List<Order>)Session["cart"];
            OrdersViewModel ordersViewModel = new OrdersViewModel();
            ordersViewModel.ProductsInCart = orders;
            return View(ordersViewModel);
        }

        public void Buy()
        {
            var contextTwo = new EntityContext();
            var or = ((Order) ((List<Order>) Session["cart"])[0]);
            db.Orders.Add(or);
        }

        [HttpPost]
        public void AddToCart(int id)
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
            /*db.Orders.Add(order);
            db.SaveChanges();*/
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
