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
    public class ChannelsController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: Channels
        [Authorize(Roles = "user")]
        public ActionResult MyChannels()
        {
            var userId = User.Identity.GetUserId();
            var channels = db.Channels.Include(c => c.AspNetUser).Where(c => c.Creator == userId).Where(c => c.Closed == false);
            return View(channels.ToList());
        }

        [Authorize(Roles = "agent")]
        public ActionResult AllChannels()
        {
            var userId = User.Identity.GetUserId();
            var channels = db.Channels.Include(c => c.AspNetUser).Where(c => c.Closed == false);
            return View(channels.ToList());
        }

        [Authorize(Roles = "agent")]
        public ActionResult SignUp(int id)
        {
            Channel channel = db.Channels.Find(id);
            channel.AspNetUsers.Add(db.AspNetUsers.Find(User.Identity.GetUserId()));
            db.Entry(channel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AllChannels");
        }

        [Authorize(Roles = "agent")]
        public ActionResult SignOff(int id)
        {
            Channel channel = db.Channels.Find(id);
            channel.AspNetUsers.Remove(db.AspNetUsers.Find(User.Identity.GetUserId()));
            db.Entry(channel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AllChannels");
        }

        // GET: Channels/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Channel channel = db.Channels.Find(id);
        //    if (channel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(channel);
        //}

        // GET: Channels/Create
        [Authorize(Roles = "user")]
        public ActionResult Create()
        {
            ViewBag.Creator = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Channels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user")]
        public ActionResult Create([Bind(Include = "Id,Name,TimeCreated,Creator,Closed,Price")] Channel channel)
        {
            if (ModelState.IsValid)
            {
                AspNetUser user = db.AspNetUsers.Find(User.Identity.GetUserId());
                int channelPrice = db.ChannelPrices.First().NumTokens;

                if (user.Tokens < channelPrice)
                {
                    return View("NeedMoreGold");
                }
                else
                {
                    channel.Closed = false;
                    channel.Creator = user.Id;
                    channel.TimeCreated = DateTime.Now;
                    channel.Price = channelPrice;
                    db.Channels.Add(channel);

                    user.Tokens -= channelPrice;
                    db.Entry(user).State = EntityState.Modified;
                
                    db.SaveChanges();
                    return RedirectToAction("MyChannels");
                }
            }

            ViewBag.Creator = new SelectList(db.AspNetUsers, "Id", "Email", channel.Creator);
            return View(channel);
        }

        [Authorize(Roles = "user")]
        public ActionResult Close(int id)
        {
            Channel channel = db.Channels.Find(id);
            channel.Closed = true;
            db.Entry(channel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("MyChannels");
        }

        // GET: Channels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Channel channel = db.Channels.Find(id);
        //    if (channel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Creator = new SelectList(db.AspNetUsers, "Id", "Email", channel.Creator);
        //    return View(channel);
        //}

        //// POST: Channels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,TimeCreated,Creator,Closed,Price")] Channel channel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(channel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Creator = new SelectList(db.AspNetUsers, "Id", "Email", channel.Creator);
        //    return View(channel);
        //}

        //// GET: Channels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Channel channel = db.Channels.Find(id);
        //    if (channel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(channel);
        //}

        //// POST: Channels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Channel channel = db.Channels.Find(id);
        //    db.Channels.Remove(channel);
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
