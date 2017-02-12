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
    public class SchedulesController : Controller
    {
        private Online_Bus_Ticketing_SystemEntities1 db = new Online_Bus_Ticketing_SystemEntities1();

        // GET: Admin/Schedules
        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Bus1).Include(s => s.Route1);
            return View(schedules.ToList());
        }

        // GET: Admin/Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: Admin/Schedules/Create
        public ActionResult Create()
        {
            ViewBag.Bus = new SelectList(db.Buses, "BusNo", "BusNo");
            ViewBag.Route = new SelectList(db.Routes, "RouteId", "RouteId");
            return View();
        }

        // POST: Admin/Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleId,TravelDate,DepartureTime,ArrivalTime,Route,Bus")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bus = new SelectList(db.Buses, "BusNo", "BusNo", schedule.Bus);
            ViewBag.Route = new SelectList(db.Routes, "RouteId", "RouteId", schedule.Route);
            return View(schedule);
        }

        // GET: Admin/Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bus = new SelectList(db.Buses, "BusNo", "BusNo", schedule.Bus);
            ViewBag.Route = new SelectList(db.Routes, "RouteId", "RouteId", schedule.Route);
            return View(schedule);
        }

        // POST: Admin/Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleId,TravelDate,DepartureTime,ArrivalTime,Route,Bus")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bus = new SelectList(db.Buses, "BusNo", "BusNo", schedule.Bus);
            ViewBag.Route = new SelectList(db.Routes, "RouteId", "RouteId", schedule.Route);
            return View(schedule);
        }

        // GET: Admin/Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Admin/Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
