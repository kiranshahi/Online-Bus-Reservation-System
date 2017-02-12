using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Bus_Reservation_System.Areas.Admin.Models;

namespace Online_Bus_Reservation_System.Areas.Admin.Controllers
{
    public class BusTypesController : Controller
    {
        private Online_Bus_Ticketing_SystemEntities1 db = new Online_Bus_Ticketing_SystemEntities1();

        // GET: Admin/BusTypes
        public ActionResult Index()
        {
            return View(db.BusTypes.ToList());
        }

        // GET: Admin/BusTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusType busType = db.BusTypes.Find(id);
            if (busType == null)
            {
                return HttpNotFound();
            }
            return View(busType);
        }

        // GET: Admin/BusTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BusTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,TotalSeat,AC")] BusType busType)
        {
            if (ModelState.IsValid)
            {
                db.BusTypes.Add(busType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busType);
        }

        // GET: Admin/BusTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusType busType = db.BusTypes.Find(id);
            if (busType == null)
            {
                return HttpNotFound();
            }
            return View(busType);
        }

        // POST: Admin/BusTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,TotalSeat,AC")] BusType busType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busType);
        }

        // GET: Admin/BusTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusType busType = db.BusTypes.Find(id);
            if (busType == null)
            {
                return HttpNotFound();
            }
            return View(busType);
        }

        // POST: Admin/BusTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusType busType = db.BusTypes.Find(id);
            db.BusTypes.Remove(busType);
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
