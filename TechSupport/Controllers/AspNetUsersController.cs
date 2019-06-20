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
    public class AspNetUsersController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: AspNetUsers
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            List<AspNetUser> users = db.AspNetUsers.ToList();
            AspNetUser adminUser = db.AspNetUsers.FirstOrDefault(user => user.Email == "admin@admin.com");
            users.Remove(adminUser);
            return View(users);
        }

        // GET: AspNetUsers/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUser aspNetUser = db.AspNetUsers.Find(id);
        //    if (aspNetUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUser);
        //}

        // GET: AspNetUsers/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        //public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "Email,UserName,FirstName,LastName")] AspNetUser aspNetUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new Models.ApplicationUser
        //        {
        //            UserName = aspNetUser.Email,
        //            Email = aspNetUser.Email,
        //            FirstName = aspNetUser.FirstName,
        //            LastName = aspNetUser.LastName
        //        };
        //        //var result = await UserManager.CreateAsync(user, "password");
        //        if (result.Succeeded)
        //        {
        //            //await UserManager.AddToRoleAsync(aspNetUser.Id, "user");
        //        }
        //        //db.AspNetUsers.Add(aspNetUser);
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(aspNetUser);
        //}

        // GET: AspNetUsers/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Email,UserName,FirstName,LastName")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: AspNetUsers/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUser aspNetUser = db.AspNetUsers.Find(id);
        //    if (aspNetUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUser);
        //}

        //// POST: AspNetUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    AspNetUser aspNetUser = db.AspNetUsers.Find(id);
        //    db.AspNetUsers.Remove(aspNetUser);
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
