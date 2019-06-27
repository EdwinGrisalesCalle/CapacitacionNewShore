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
    public class BagController : Controller
    {
        private AnsermaAirProyectContext db = new AnsermaAirProyectContext();

        // GET: Bag
        public ActionResult Index()
        {
            //var passengers = db.Passengers.Include(b => b.name);
            var passengers = db.Passengers.Include(p => p.Id);
            return View(db.Bags.ToList());

            //var services = db.Services.Include(b => b.passenger);
            //return View(services.ToList());
        }

        // GET: Bag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }

        // GET: Bag/Create
        public ActionResult Create()
        {
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name");
            return View();
        }

        // POST: Bag/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,price,passengerId,weight,size")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(bag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", bag.passengerId);
            return View(bag);
        }

        // GET: Bag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", bag.passengerId);
            return View(bag);
        }

        // POST: Bag/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,price,passengerId,weight,size")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", bag.passengerId);
            return View(bag);
        }

        // GET: Bag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = db.Bags.Find(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }

        // POST: Bag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bag bag = db.Bags.Find(id);
            db.Services.Remove(bag);
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
