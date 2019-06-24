﻿using Microsoft.AspNet.Identity;
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
        public ActionResult Details(int? id, string sort)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = 
                db.Answers
                .Include(a => a.Answers1.Select(a1 => a1.AspNetUser))
                .SingleOrDefault(a => a.Id == id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            if (sort != null)
            {
                string sortOrder = (string)TempData["sortOrder"];
                if (sortOrder != null && sortOrder.Contains(sort) && sortOrder.Contains("desc"))
                {
                    sortOrder = sort + "_" + "asc";
                }
                else
                {
                    sortOrder = sort + "_" + "desc";
                }
                TempData["sortOrder"] = sortOrder;

            }

            return View(answer);
        }

        public Answer SortAnswers(Answer answer, string sortOrder)
        {
            switch (sortOrder)
            {
                case "time_asc":
                    answer.Answers1 = answer.Answers1.OrderBy(a => a.TimeCreated).ToList();
                    break;
                case "time_desc":
                    answer.Answers1 = answer.Answers1.OrderByDescending(a => a.TimeCreated).ToList();
                    break;
                case "likes_asc":
                    answer.Answers1 = answer.Answers1.OrderBy(a => a.Ratings.Where(r => r.Likes.Equals(true)).Count()).ToList();
                    break;
                case "likes_desc":
                    answer.Answers1 = answer.Answers1.OrderByDescending(a => a.Ratings.Where(r => r.Likes.Equals(true)).Count()).ToList();
                    break;
                case "dislikes_asc":
                    answer.Answers1 = answer.Answers1.OrderBy(a => a.Ratings.Where(r => r.Likes.Equals(false)).Count()).ToList();
                    break;
                case "dislikes_desc":
                    answer.Answers1 = answer.Answers1.OrderByDescending(a => a.Ratings.Where(r => r.Likes.Equals(false)).Count()).ToList();
                    break;
            }
            return answer;
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
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Answer answer = db.Answers.Find(id);
        //    if (answer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ReplyOn = new SelectList(db.Answers, "Id", "Author", answer.ReplyOn);
        //    ViewBag.Author = new SelectList(db.AspNetUsers, "Id", "Email", answer.Author);
        //    ViewBag.Question = new SelectList(db.Questions, "Id", "Title", answer.Question);
        //    return View(answer);
        //}

        //// POST: Answers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Question,ReplyOn,Author,TimeCreated,Text")] Answer answer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(answer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ReplyOn = new SelectList(db.Answers, "Id", "Author", answer.ReplyOn);
        //    ViewBag.Author = new SelectList(db.AspNetUsers, "Id", "Email", answer.Author);
        //    ViewBag.Question = new SelectList(db.Questions, "Id", "Title", answer.Question);
        //    return View(answer);
        //}

        // GET: Answers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Answer answer = db.Answers.Find(id);
        //    if (answer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(answer);
        //}

        //// POST: Answers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Answer answer = db.Answers.Include(a => a.Answers1).SingleOrDefault(a => a.Id.Equals(id));
        //    DeleteAnswer(answer);
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int AnswerId, int QuestionId)
        {
            Answer answer = db.Answers.Include(a => a.Answers1).SingleOrDefault(a => a.Id.Equals(AnswerId));
            DeleteAnswer(answer);
            return Redirect("/Questions/Details/" + QuestionId);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int AnswerId)
        {
            Answer answer = db.Answers.Include(a => a.Answers1).SingleOrDefault(a => a.Id.Equals(AnswerId));
            DeleteAnswer(answer);
            return Redirect("/Answers/Details/" + AnswerId);
        }

        public void DeleteAnswer(Answer answer)
        {
            if (answer.Answers1 != null)
            {
                foreach (var a in answer.Answers1.ToList())
                {
                    Answer ans = db.Answers.Include(an => an.Answers1).SingleOrDefault(an => an.Id.Equals(a.Id));
                    DeleteAnswer(ans);
                }
            } 
            db.Answers.Remove(answer);
            db.SaveChanges();            
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
