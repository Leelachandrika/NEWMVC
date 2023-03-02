using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoManagement;

namespace CargoManagement.Controllers
{
    [Authorize]
    public class bookingCargoesController : Controller
    {
        private Model1 db = new Model1();

        // GET: bookingCargoes
       // [Authorize(Roles ="Customer")]
        public ActionResult Index()
        {
            var bookingCargos = db.bookingCargos.Include(b => b.customer).Include(b => b.product);
            return View(bookingCargos.ToList());
        }

        // GET: bookingCargoes/Details/5

        //[Authorize(Roles = "Customer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookingCargo bookingCargo = db.bookingCargos.Find(id);
            if (bookingCargo == null)
            {
                return HttpNotFound();
            }
            return View(bookingCargo);
        }

        // GET: bookingCargoes/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name");
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name");
            return View();
        }

        // POST: bookingCargoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_id,customer_id,product_id,quantity,total_cost,booking_date")] bookingCargo bookingCargo)
        {
            if (ModelState.IsValid)
            {
                db.bookingCargos.Add(bookingCargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name", bookingCargo.customer_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", bookingCargo.product_id);
            return View(bookingCargo);
        }

        // GET: bookingCargoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookingCargo bookingCargo = db.bookingCargos.Find(id);
            if (bookingCargo == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name", bookingCargo.customer_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", bookingCargo.product_id);
            return View(bookingCargo);
        }

        // POST: bookingCargoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id,customer_id,product_id,quantity,total_cost,booking_date")] bookingCargo bookingCargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingCargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "customer_name", bookingCargo.customer_id);
            ViewBag.product_id = new SelectList(db.products, "product_id", "product_name", bookingCargo.product_id);
            return View(bookingCargo);
        }

        // GET: bookingCargoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookingCargo bookingCargo = db.bookingCargos.Find(id);
            if (bookingCargo == null)
            {
                return HttpNotFound();
            }
            return View(bookingCargo);
        }

        // POST: bookingCargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookingCargo bookingCargo = db.bookingCargos.Find(id);
            db.bookingCargos.Remove(bookingCargo);
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
    }
}
