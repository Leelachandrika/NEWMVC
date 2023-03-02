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
    public class gatePassesController : Controller
    {
        private Model1 db = new Model1();

        // GET: gatePasses
        public ActionResult Index()
        {
            var gatePasses = db.gatePasses.Include(g => g.city);
            return View(gatePasses.ToList());
        }

        // GET: gatePasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gatePass gatePass = db.gatePasses.Find(id);
            if (gatePass == null)
            {
                return HttpNotFound();
            }
            return View(gatePass);
        }

        // GET: gatePasses/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.cities, "city_id", "state");
            return View();
        }

        // POST: gatePasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "number,truck_number,city_id,issued_date")] gatePass gatePass)
        {
            if (ModelState.IsValid)
            {
                db.gatePasses.Add(gatePass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.cities, "city_id", "state", gatePass.city_id);
            return View(gatePass);
        }

        // GET: gatePasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gatePass gatePass = db.gatePasses.Find(id);
            if (gatePass == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.cities, "city_id", "state", gatePass.city_id);
            return View(gatePass);
        }

        // POST: gatePasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "number,truck_number,city_id,issued_date")] gatePass gatePass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gatePass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.cities, "city_id", "state", gatePass.city_id);
            return View(gatePass);
        }

        // GET: gatePasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gatePass gatePass = db.gatePasses.Find(id);
            if (gatePass == null)
            {
                return HttpNotFound();
            }
            return View(gatePass);
        }

        // POST: gatePasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gatePass gatePass = db.gatePasses.Find(id);
            db.gatePasses.Remove(gatePass);
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
