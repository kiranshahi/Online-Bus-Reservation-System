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
    public class RoutesController : Controller
    {
        private Online_Bus_Ticketing_SystemEntities1 db = new Online_Bus_Ticketing_SystemEntities1();

        // GET: Admin/Routes
        public ActionResult Index()
        {
            var routes = db.Routes.Include(r => r.City).Include(r => r.City1).Include(r => r.Route1).Include(r => r.Route2);
            return View(routes.ToList());
        }

        // GET: Admin/Routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Admin/Routes/Create
        public ActionResult Create()
        {
            ViewBag.CityFrom = new SelectList(db.Cities, "CitiesId", "CityName");
            ViewBag.CityTo = new SelectList(db.Cities, "CitiesId", "CityName");
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId");
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId");
            return View();
        }

        // POST: Admin/Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteId,CityFrom,CityTo,Fare")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Routes.Add(route);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityFrom = new SelectList(db.Cities, "CitiesId", "CityName", route.CityFrom);
            ViewBag.CityTo = new SelectList(db.Cities, "CitiesId", "CityName", route.CityTo);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId", route.RouteId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId", route.RouteId);
            return View(route);
        }

        // GET: Admin/Routes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityFrom = new SelectList(db.Cities, "CitiesId", "CityName", route.CityFrom);
            ViewBag.CityTo = new SelectList(db.Cities, "CitiesId", "CityName", route.CityTo);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId", route.RouteId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId", route.RouteId);
            return View(route);
        }

        // POST: Admin/Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteId,CityFrom,CityTo,Fare")] Route route)
        {
            if (ModelState.IsValid)
            {
                db.Entry(route).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityFrom = new SelectList(db.Cities, "CitiesId", "CityName", route.CityFrom);
            ViewBag.CityTo = new SelectList(db.Cities, "CitiesId", "CityName", route.CityTo);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId", route.RouteId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteId", route.RouteId);
            return View(route);
        }

        // GET: Admin/Routes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Admin/Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Route route = db.Routes.Find(id);
            db.Routes.Remove(route);
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
