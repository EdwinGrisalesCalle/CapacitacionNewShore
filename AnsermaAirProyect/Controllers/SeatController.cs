using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnsermaAirProyect.Models;

namespace AnsermaAirProyect.Controllers
{
    public class SeatController : Controller
    {
        private AnsermaAirProyectContext db = new AnsermaAirProyectContext();

        // GET: Seat
        public ActionResult Index()
        {
            return View(db.Seats.ToList());

            //var services = db.Services.Include(s => s.passenger);
            //return View(services.ToList());
        }

        // GET: Seat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // GET: Seat/Create
        public ActionResult Create()
        {
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name");
            return View();
        }

        // POST: Seat/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,price,passengerId,seatCod")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(seat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", seat.passengerId);
            return View(seat);
        }

        // GET: Seat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", seat.passengerId);
            return View(seat);
        }

        // POST: Seat/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,price,passengerId,seatCod")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", seat.passengerId);
            return View(seat);
        }

        // GET: Seat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // POST: Seat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seat seat = db.Seats.Find(id);
            db.Services.Remove(seat);
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
