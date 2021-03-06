﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;
using TrashCollection.Models.ViewModels;

namespace TrashCollection.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        public ActionResult Home()
        {
            var userId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
            PickupViewModels pickupInfo = new PickupViewModels()
            {
                Pickup = new Pickups(),
                OneTimePickup = new Pickups(),
                Customer = new Customer()
            };
            pickupInfo.OneTimePickup = db.Pickups.Where(p => p.CustomerId == customer.CustomerId && p.Repeat == false).FirstOrDefault();
            pickupInfo.Pickup = db.Pickups.Where(p => p.CustomerId == customer.CustomerId && p.Repeat == true).FirstOrDefault();
            pickupInfo.Customer = customer;
            return View(pickupInfo);
        }
       
        // GET: Pickups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Pickups/Create
        // GET: CustomerModels/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            Customer customer = new Customer();
            customer.ApplicationUserId = user.Id;
            customer.Email = user.Email;
            customer.Username = user.UserName;
            return View(customer);
        }

        // POST: CustomerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,ApplicationUserId,Username,FirstName,LastName,Email,Address,ZipCode,AmountDue,FullName")] Customer customer)
        {
            customer.FullName = customer.FirstName + " " + customer.LastName;
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index","Home", null);
            }

            return View(customer);
        }

        // GET: Pickups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: CustomerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,ApplicationUserId,Username,FirstName,LastName,Email,Address,ZipCode,AmountDue,PickupDate,FullName")] Customer customer)
        {
            customer.FullName = customer.FirstName + " " + customer.LastName;
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
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
