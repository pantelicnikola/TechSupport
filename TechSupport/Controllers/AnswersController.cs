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
    public class AnswersController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: Answers
        public ActionResult Index()
        {
            var answers = db.Answers.Include(a => a.Answer1).Include(a => a.AspNetUser).Include(a => a.Question1);
            return View(answers.ToList());
        }

        // GET: Answers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answers/Create
        public ActionResult Create(int? QuestionId, int? ReplyOn)
        {
            ViewBag.ReplyOn = new SelectList(db.Answers, "Id", "Author");
            ViewBag.Author = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Question = new SelectList(db.Questions, "Id", "Title");
            TempData["QuestionToAnswer"] = QuestionId;
            TempData["AnswerToReply"] = ReplyOn;
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Text")] Answer answer)
        {
            int? QuestionId = (int?)TempData["QuestionToAnswer"];
            int? ReplyOn = (int?)TempData["AnswerToReply"];
            if (ModelState.IsValid)
            {
                answer.TimeCreated = DateTime.Now;
                answer.Upvotes = 0;
                answer.Downvotes = 0;
                answer.Question = QuestionId;
                answer.Author = User.Identity.GetUserId();
                answer.ReplyOn = ReplyOn;
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("Index", "Questions");
            }

            ViewBag.ReplyOn = new SelectList(db.Answers, "Id", "Author", answer.ReplyOn);
            ViewBag.Author = new SelectList(db.AspNetUsers, "Id", "Email", answer.Author);
            ViewBag.Question = new SelectList(db.Questions, "Id", "Title", answer.Question);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReplyOn = new SelectList(db.Answers, "Id", "Author", answer.ReplyOn);
            ViewBag.Author = new SelectList(db.AspNetUsers, "Id", "Email", answer.Author);
            ViewBag.Question = new SelectList(db.Questions, "Id", "Title", answer.Question);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,ReplyOn,Author,TimeCreated,Text,Upvotes,Downvotes")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReplyOn = new SelectList(db.Answers, "Id", "Author", answer.ReplyOn);
            ViewBag.Author = new SelectList(db.AspNetUsers, "Id", "Email", answer.Author);
            ViewBag.Question = new SelectList(db.Questions, "Id", "Title", answer.Question);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
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
