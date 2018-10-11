using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;
using TrashCollection.Models.ViewModels;

namespace TrashCollection.Controllers
{
    public class PickupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pickups
        public ActionResult Index()
        {
            var pickups = db.Pickups.ToList();
            return View(pickups);
        }

        public ActionResult _IndexPickupsByZip(int id)
        {
            var employee = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            var pickups = db.Pickups.Where(p => p.Zipcode == employee.Zipcode).ToList();
            return View(pickups);
        }

        // GET: Pickups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickups pickups = db.Pickups.Find(id);
            if (pickups == null)
            {
                return HttpNotFound();
            }
            return View(pickups);
        }


        //public ActionResult CreateOneTime(int id)
        //{
        //    var pickup = db.Pickups.Where(p => p.CustomerId == id).FirstOrDefault();
        //    return View(pickup);
        //}

        //[HttpPost]
        //public ActionResult SetPickupDay([Bind(Include = "PickupId,PickupWeekDay,PickupDate,CustomerId,Zipcode,Repeat,IsCompleted,PickupCost")] Pickups pickup
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Pickups.Add(pickup);
        //        db.SaveChanges();
        //        return RedirectToAction("Home", "Client", null);
        //    }

        //    return View();
        //}


        public ActionResult SetPickupDay(int id)
        {
            var pickup = db.Pickups.Where(p => p.CustomerId == id).FirstOrDefault();
            return View(pickup);
        }

        [HttpPost]
        public ActionResult SetPickupDay([Bind(Include = "PickupId,PickupWeekDay,PickupDate,CustomerId,Zipcode,Repeat,IsCompleted,PickupCost")] Pickups pickup, string options)
        {

            if (ModelState.IsValid)
            {
                db.Pickups.Add(pickup);
                db.SaveChanges();
                return RedirectToAction("Home", "Client", null);
            }

            return View();
        }

        // GET: Pickups/Create
        public ActionResult Create(int id)
        {
            var Pickup = new Pickups();
            var customer = db.Customers.Where(c => c.CustomerId == id).FirstOrDefault();

            Pickup.CustomerId = customer.CustomerId;
            Pickup.Customer = customer;
            Pickup.PickupCost = 50.00;
            Pickup.Repeat = true;
            Pickup.Zipcode = customer.ZipCode;
           
            return View(Pickup);
        }

        // POST: Pickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickupId,PickupWeekDay,PickupDate,CustomerId,Zipcode,Repeat,IsCompleted,PickupCost")] Pickups pickup)
        {
            if (ModelState.IsValid)
            {

                db.Pickups.Add(pickup);
                db.SaveChanges();
                return RedirectToAction("SetPickupDay", new { id = pickup.PickupId});
            }

            return View(pickup);
        }

        // GET: Pickups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickups pickups = db.Pickups.Find(id);
            if (pickups == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomersId", "Username", pickups.CustomerId);
            return View(pickups);
        }

        // POST: Pickups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PickupId,PickupWeekDay,PickupDate,CustomerId,Zipcode,Repeat,IsCompleted,PickupCost")] Pickups pickups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomersId", "Username", pickups.CustomerId);
            return View(pickups);
        }

        // GET: Pickups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pickups pickups = db.Pickups.Find(id);
            if (pickups == null)
            {
                return HttpNotFound();
            }
            return View(pickups);
        }

        // POST: Pickups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pickups pickups = db.Pickups.Find(id);
            db.Pickups.Remove(pickups);
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
