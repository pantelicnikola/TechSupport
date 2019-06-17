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
using TechSupport.Models;

namespace TechSupport.Controllers
{
    public class QuestionsController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Channel1).Include(q => q.Category1);
            List<QuestionsIndexViewModel> questionList = new List<QuestionsIndexViewModel>();
            foreach (var question in questions)
            {
                var user = db.AspNetUsers.FirstOrDefault(usr => question.Author == usr.Id);
                QuestionsIndexViewModel model = new QuestionsIndexViewModel()
                {
                    Question = question,
                    AuthorName = user.FirstName + user.LastName
                };
                questionList.Add(model);
            }
            return View(questionList);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.Channel = new SelectList(db.Channels, "Id", "Name");
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,Image,Category,Author,TimeCreated,TimeLastLocked,LockoutEnabled,Channel,Locked")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.Author = User.Identity.GetUserId();
                question.TimeCreated = DateTime.Now;
                question.Locked = false;
                question.LockoutEnabled = true;

                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Channel = new SelectList(db.Channels, "Id", "Name", question.Channel);
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name", question.Category);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.Channel = new SelectList(db.Channels, "Id", "Name", question.Channel);
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name", question.Category);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Image,Category,Author,TimeCreated,TimeLastLocked,LockoutEnabled,Channel,Locked")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Channel = new SelectList(db.Channels, "Id", "Name", question.Channel);
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name", question.Category);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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

        public ActionResult Close(int id)
        {
            Question question = db.Questions.Find(id);
            question.Locked = true;
            question.TimeLastLocked = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
