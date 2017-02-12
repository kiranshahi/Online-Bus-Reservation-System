using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Bus_Reservation_System.Models;

namespace Online_Bus_Reservation_System.Areas.Admin.Controllers
{
    public class BusesController : Controller
    {
        private Online_Bus_Ticketing_SystemEntities db = new Online_Bus_Ticketing_SystemEntities();

        // GET: Admin/Buses
        public ActionResult Index()
        {
            var buses = db.Buses.Include(b => b.BusType1);
            return View(buses.ToList());
        }

        // GET: Admin/Buses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: Admin/Buses/Create
        public ActionResult Create()
        {
            ViewBag.BusType = new SelectList(db.BusTypes, "TypeId", "TypeId");
            return View();
        }

        // POST: Admin/Buses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusNo,BusType")] Bus bus)
        {
            if (ModelState.IsValid)
            {
               // User.Identity.Name
                db.Buses.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusType = new SelectList(db.BusTypes, "TypeId", "TypeId", bus.BusType);
            return View(bus);
        }

        // GET: Admin/Buses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusType = new SelectList(db.BusTypes, "TypeId", "TypeId", bus.BusType);
            return View(bus);
        }

        // POST: Admin/Buses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusNo,BusType")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusType = new SelectList(db.BusTypes, "TypeId", "TypeId", bus.BusType);
            return View(bus);
        }

        // GET: Admin/Buses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Admin/Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bus bus = db.Buses.Find(id);
            db.Buses.Remove(bus);
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
