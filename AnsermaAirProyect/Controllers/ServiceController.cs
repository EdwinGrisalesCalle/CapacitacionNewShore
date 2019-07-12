using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnsermaAirProyect.Models;
using Newtonsoft.Json;

namespace AnsermaAirProyect.Controllers
{
    public class ServiceController : Controller
    {
        private AnsermaAirProyectContext db = new AnsermaAirProyectContext();

        // GET: Service
        // GET: Service
        public ActionResult Index()
        {
            //RestSharp.RestClient client = new RestSharp.RestClient("https://localhost:44361");
            //RestSharp.RestRequest request = new RestSharp.RestRequest
            //{
            //    Resource = "Api/Values",
            //    Method = RestSharp.Method.GET

            //};
            //var response = client.Execute(request);
            //ViewBag.Comidas = response.Content;


            //return View(db.Services.ToList());

            var services = db.Services.Include(s => s.passenger);
            return View(services.ToList());
        }

        // GET: Service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name");
            return View();
        }

        // POST: Service/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,price,passengerId")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", service.passengerId);
            return View(service);
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", service.passengerId);
            return View(service);
        }

        // POST: Service/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,price,passengerId")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.passengerId = new SelectList(db.Passengers, "Id", "name", service.passengerId);
            return View(service);
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
