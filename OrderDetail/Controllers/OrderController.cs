using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderDetail.Models;
using System.Data.SqlClient;

namespace OrderDetail.Controllers
{
    public class OrderController : Controller
    {
        private OrderEntryDbContext db = new OrderEntryDbContext();

        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View(db.orders.ToList());
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id = 0)
        {
            OrderTbl ordertbl = db.orders.Find(id);
            if (ordertbl == null)
            {
                return HttpNotFound();
            }

            List<OrderDetail.Models.OrderDetail> details =
                db.orderDetails.SqlQuery(
                    "SELECT OrdLineId, l.ProdNo, p.ProdName, l.Qty, p.ProdPrice " +
                    "FROM OrderTbl o, OrdLine l, Product p " +
                    "WHERE o.OrdNo = l.OrdNo " +
                    "  AND l.ProdNo = p.ProdNo " +
                    "  AND o.OrdId = @OrdId "
                    , new SqlParameter("OrdId", id)).ToList();

            ViewBag.orderDetails = details;

            return View(ordertbl);

        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(OrderTbl ordertbl)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(ordertbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordertbl);
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrderTbl ordertbl = db.orders.Find(id);
            if (ordertbl == null)
            {
                return HttpNotFound();
            }
            return View(ordertbl);
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderTbl ordertbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordertbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordertbl);
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrderTbl ordertbl = db.orders.Find(id);
            if (ordertbl == null)
            {
                return HttpNotFound();
            }
            return View(ordertbl);
        }

        //
        // POST: /Order/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderTbl ordertbl = db.orders.Find(id);
            db.orders.Remove(ordertbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}