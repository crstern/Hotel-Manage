using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_Manage.Models;
using System.Data.Entity.Core.Objects;

namespace Hotel_Manage.Controllers.subfolder
{
    public class RoomsController : Controller
    {
        private DbCtx db = new DbCtx();

        // GET: Rooms
        public ActionResult Index()
        {
            return View(db.Rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room reqRoom = db.Rooms.Find(id);
            if (reqRoom == null)
            {
                return HttpNotFound();
            }
            var reservedDates = db.Reservations
                .Where(r => r.RoomId == reqRoom.Id)
                .Select(r => new { r.StartDate, r.EndDate })
                .ToList();

            DateTime day = DateTime.Today;
            TimeSpan span = new TimeSpan(1, 0, 0, 0); // interval de o zi
            ICollection<DateTime> avaliableDates = new List<DateTime>();

            for (int i = 0;i < 90; i++)
            {
                bool isDayAvaliable = true;
                for (int j = 0;j < reservedDates.Count; j++)
                {
                    if (day >= reservedDates[j].StartDate && day <= reservedDates[j].EndDate)
                    {
                        isDayAvaliable = false;
                        break;
                    }
                }
                if (isDayAvaliable)
                    avaliableDates.Add(day);
                day += span;
            }
            ViewBag.AvaliableDates = avaliableDates;
            return View(reqRoom);
        }

        // GET: Rooms/Create
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Create([Bind(Include = "Id,CurrentlyBooked,CurrentCustomerId,RoomSize,PricePerNight")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }

        // GET: Rooms/Edit/5
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employee,Admin")]
        public ActionResult Edit([Bind(Include = "Id,CurrentlyBooked,CurrentCustomerId,RoomSize,PricePerNight")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
