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
    public class ChannelPricesController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: ChannelPrices
        //public ActionResult Index()
        //{
        //    return View(db.ChannelPrices.ToList());
        //}

        //// GET: ChannelPrices/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChannelPrice channelPrice = db.ChannelPrices.Find(id);
        //    if (channelPrice == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(channelPrice);
        //}

        //// GET: ChannelPrices/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ChannelPrices/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,NumTokens")] ChannelPrice channelPrice)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ChannelPrices.Add(channelPrice);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(channelPrice);
        //}

        // GET: ChannelPrices/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit()
        {
            ChannelPrice channelPrice = db.ChannelPrices.First();
            if (channelPrice == null)
            {
                return HttpNotFound();
            }
            return View(channelPrice);
        }

        // POST: ChannelPrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,NumTokens")] ChannelPrice channelPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channelPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }
            return View(channelPrice);
        }

        // GET: ChannelPrices/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ChannelPrice channelPrice = db.ChannelPrices.Find(id);
        //    if (channelPrice == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(channelPrice);
        //}

        //// POST: ChannelPrices/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ChannelPrice channelPrice = db.ChannelPrices.Find(id);
        //    db.ChannelPrices.Remove(channelPrice);
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
