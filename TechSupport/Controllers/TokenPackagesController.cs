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
    public class TokenPackagesController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: TokenPackages
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.TokenPackages.ToList());
        }

        // GET: TokenPackages/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TokenPackage tokenPackage = db.TokenPackages.Find(id);
        //    if (tokenPackage == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tokenPackage);
        //}

        // GET: TokenPackages/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TokenPackages/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,NumTokens,Price")] TokenPackage tokenPackage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TokenPackages.Add(tokenPackage);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tokenPackage);
        //}

        // GET: TokenPackages/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TokenPackage tokenPackage = db.TokenPackages.Find(id);
            if (tokenPackage == null)
            {
                return HttpNotFound();
            }
            return View(tokenPackage);
        }

        // POST: TokenPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,NumTokens,Price")] TokenPackage tokenPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tokenPackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tokenPackage);
        }

        // GET: TokenPackages/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TokenPackage tokenPackage = db.TokenPackages.Find(id);
        //    if (tokenPackage == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tokenPackage);
        //}

        //// POST: TokenPackages/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TokenPackage tokenPackage = db.TokenPackages.Find(id);
        //    db.TokenPackages.Remove(tokenPackage);
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
