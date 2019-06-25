using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechSupport;

namespace TechSupport.Controllers
{
    public class TokenOrdersController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: TokenOrders
        //public ActionResult Index()
        //{
        //    var tokenOrders = db.TokenOrders.Include(t => t.AspNetUser).Include(t => t.TokenPackage1);
        //    return View(tokenOrders.ToList());
        //}

        //// GET: TokenOrders/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TokenOrder tokenOrder = db.TokenOrders.Find(id);
        //    if (tokenOrder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tokenOrder);
        //}

        [Authorize(Roles = "user")]
        public ActionResult MyOrders()
        {
            var userId = User.Identity.GetUserId();
            var tokenOrders = db.TokenOrders.Include(t => t.AspNetUser).Include(t => t.TokenPackage1).Where(t => t.Buyer == userId);
            return View(tokenOrders.ToList());
        }

        // GET: TokenOrders/Create
        [Authorize(Roles = "user")]
        public ActionResult Create()
        {
            ViewBag.Buyer = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.TokenPackage = new SelectList(db.TokenPackages, "Id", "Name");
            return View();
        }

        // POST: TokenOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user")]
        public ActionResult Create([Bind(Include = "Id,TokenPackage")] TokenOrder tokenOrder)
        {
            if (ModelState.IsValid)
            {
                tokenOrder.Buyer = User.Identity.GetUserId();
                TokenPackage selectedPackage = db.TokenPackages.Find(tokenOrder.TokenPackage);
                tokenOrder.Price = selectedPackage.Price;
                tokenOrder.NumTokens = selectedPackage.NumTokens;
                db.TokenOrders.Add(tokenOrder);
                db.SaveChanges();
                return RedirectToAction("MyOrders");
            }

            ViewBag.Buyer = new SelectList(db.AspNetUsers, "Id", "Email", tokenOrder.Buyer);
            ViewBag.TokenPackage = new SelectList(db.TokenPackages, "Id", "Name", tokenOrder.TokenPackage);
            return View(tokenOrder);
        }

        // GET: TokenOrders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TokenOrder tokenOrder = db.TokenOrders.Find(id);
        //    if (tokenOrder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Buyer = new SelectList(db.AspNetUsers, "Id", "Email", tokenOrder.Buyer);
        //    ViewBag.TokenPackage = new SelectList(db.TokenPackages, "Id", "Name", tokenOrder.TokenPackage);
        //    return View(tokenOrder);
        //}

        //// POST: TokenOrders/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Buyer,NumTokens,Price,TokenPackage")] TokenOrder tokenOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tokenOrder).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Buyer = new SelectList(db.AspNetUsers, "Id", "Email", tokenOrder.Buyer);
        //    ViewBag.TokenPackage = new SelectList(db.TokenPackages, "Id", "Name", tokenOrder.TokenPackage);
        //    return View(tokenOrder);
        //}

        //// GET: TokenOrders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TokenOrder tokenOrder = db.TokenOrders.Find(id);
        //    if (tokenOrder == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tokenOrder);
        //}

        //// POST: TokenOrders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TokenOrder tokenOrder = db.TokenOrders.Find(id);
        //    db.TokenOrders.Remove(tokenOrder);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
