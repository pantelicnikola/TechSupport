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
    public class RatingsController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: Ratings
        public ActionResult Index()
        {
            var ratings = db.Ratings.Include(r => r.Answer1).Include(r => r.AspNetUser1);
            return View(ratings.ToList());
        }

        // GET: Ratings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // GET: Ratings/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Answer = new SelectList(db.Answers, "Id", "Author");
        //    ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email");
        //    return View();
        //}

        // POST: Ratings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "AspNetUser,Answer,Likes")] Rating rating)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Ratings.Add(rating);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Answer = new SelectList(db.Answers, "Id", "Author", rating.Answer);
        //    ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", rating.AspNetUser);
        //    return View(rating);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(string UserId, int AnswerId, bool Likes)
        {
            Rating rating = new Rating
            {
                AspNetUser = UserId,
                Answer = AnswerId,
                Likes = Likes
            };
            db.Ratings.Add(rating);
            db.SaveChanges();
            
            return null;
        }

        // GET: Ratings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.Answer = new SelectList(db.Answers, "Id", "Author", rating.Answer);
            ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", rating.AspNetUser);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AspNetUser,Answer,Likes")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Answer = new SelectList(db.Answers, "Id", "Author", rating.Answer);
            ViewBag.AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", rating.AspNetUser);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = db.Ratings.Find(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Rating rating = db.Ratings.Find(id);
            db.Ratings.Remove(rating);
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
