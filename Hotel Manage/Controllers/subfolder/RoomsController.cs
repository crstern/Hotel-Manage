using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Hotel_Manage.Models;

namespace Hotel_Manage.Controllers
{
    public class RoomsController : Controller
    {
        private DbCtx ctx = new DbCtx();

        //Index
        public ActionResult Index()
        {
            List<Room> rooms = ctx.Rooms.ToList();  
            return View(rooms);
        }

        //Details
        public ActionResult Details(int? id)
        {
            Room room = ctx.Rooms.Find(id);
            if (id.HasValue)
            {
                // verific daca am utilizatorul a transmis parametrul id
                if (room == null)
                {
                    // daca camera nu exista, returneaza 404
                    return HttpNotFound("Couldn't find the room with id " + id.ToString() + "!");
                }
                return View(room);
            }
            return HttpNotFound("Missing book id parameter!");
        }

        //New
        [HttpGet]
        public ActionResult Create()
        {
            Room room = new Room();
            room.CurrentlyBooked = false;
            room.CurrentCustomerId = -1;
            room.Reservations = new List<int>();
            room.Jobs = new List<int>();
            return View(room);
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ctx.Rooms.Add(room);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(room);
            }
            catch (Exception e)
            {
                return View(room);
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Room room = ctx.Rooms.Find(id);
            if (room == null)
                return HttpNotFound("Couldn't find the room with id " + id.ToString() + "!");
            ctx.Rooms.Remove(room);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
