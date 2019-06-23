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
using PagedList;

namespace TechSupport.Controllers
{
    public class QuestionsController : Controller
    {
        private TechSupport20190613121821_dbEntities db = new TechSupport20190613121821_dbEntities();

        // GET: Questions
        public ActionResult Index(int page)
        {
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name");
            var questions = db.Questions.Include(q => q.Channel1).Include(q => q.Category1);
            List<QuestionsIndexViewModelItem> questionList = new List<QuestionsIndexViewModelItem>();
            foreach (var question in questions)
            {
                var user = db.AspNetUsers.FirstOrDefault(usr => question.Author == usr.Id);
                QuestionsIndexViewModelItem modelItem = new QuestionsIndexViewModelItem()
                {
                    Question = question,
                    AuthorName = user.FirstName + " " + user.LastName,
                    AnswerCount = question.Answers.Count()
                };
                questionList.Add(modelItem);
            }
            QuestionsIndexViewModel model = new QuestionsIndexViewModel();
            model.Questions = questionList.ToPagedList(page,10);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(QuestionsIndexViewModel model)
        {
            ViewBag.Category = new SelectList(db.Categories, "Id", "Name");
            var questions = db.Questions.Include(q => q.Channel1).Include(q => q.Category1).Where(question => question.Category == model.Category);
            List<QuestionsIndexViewModelItem> questionList = new List<QuestionsIndexViewModelItem>();
            foreach (var question in questions)
            {
                var user = db.AspNetUsers.FirstOrDefault(usr => question.Author == usr.Id);
                QuestionsIndexViewModelItem modelItem = new QuestionsIndexViewModelItem()
                {
                    Question = question,
                    AuthorName = user.FirstName + " " + user.LastName,
                    AnswerCount = question.Answers.Count()
                };
                questionList.Add(modelItem);
            }
            QuestionsIndexViewModel newModel = new QuestionsIndexViewModel();
            newModel.Questions = questionList.ToPagedList(1, 10);
            return View(newModel);
        }

        public ActionResult Rate(string UserId, int AnswerId, bool Likes)
        {
            Rating rating = new Rating
            {
                AspNetUser = UserId,
                Answer = AnswerId,
                Likes = Likes
            };
            db.Ratings.Add(rating);
            db.SaveChanges();
            return View();
        }

        [Authorize(Roles = "user")]
        public ActionResult MyQuestions()
        {
            var userId = User.Identity.GetUserId();
            var questions = db.Questions.Include(q => q.Channel1).Include(q => q.Category1).Where(question => question.Author == userId);
            var user = db.AspNetUsers.FirstOrDefault(usr => userId == usr.Id);
            List<QuestionsIndexViewModelItem> questionList = new List<QuestionsIndexViewModelItem>();
            foreach (var question in questions)
            {
                QuestionsIndexViewModelItem modelItem = new QuestionsIndexViewModelItem()
                {
                    Question = question,
                    AuthorName = user.FirstName + " " + user.LastName,
                    AnswerCount = question.Answers.Count()
                };
                questionList.Add(modelItem);
            }
            return View(questionList);
        }

        public ActionResult Search()
        {
            QuestionsSearchViewModel model = new QuestionsSearchViewModel();
            model.Questions = new List<QuestionsIndexViewModelItem>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(QuestionsSearchViewModel model)
        {
            var questions = db.Questions.Include(q => q.Channel1).Include(q => q.Category1).Where(question => question.Title.Contains(model.SearchString));
            List<QuestionsIndexViewModelItem> questionList = new List<QuestionsIndexViewModelItem>();
            
            foreach (var question in questions)
            {
                var user = db.AspNetUsers.FirstOrDefault(usr => question.Author == usr.Id);
                QuestionsIndexViewModelItem modelItem = new QuestionsIndexViewModelItem()
                {
                    Question = question,
                    AuthorName = user.FirstName + " " + user.LastName,
                    AnswerCount = question.Answers.Count()
                };
               questionList.Add(modelItem);
            }
            QuestionsSearchViewModel newModel = new QuestionsSearchViewModel();
            newModel.Questions = questionList;
            return View(newModel);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id, string sort)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string sortOrder = (string)TempData["sortOrder"];
            if (sortOrder != null && sortOrder.Contains(sort) && sortOrder.Contains("desc"))
            {
                sortOrder = sort + "_" + "asc";
            } else
            {
                sortOrder = sort + "_" + "desc";
            }
            TempData["sortOrder"] = sortOrder;

            Question question = 
                db.Questions
                .Include(q => q.Answers.Select(a => a.AspNetUser))
                .Include(q => q.Answers.Select(a => a.Answers1.Select(asd => asd.Answers1.Select(sdf => sdf.Answers1))))
                .SingleOrDefault(q => q.Id == id);
            if (question == null)
            {
                return HttpNotFound();
            }
            question = SortAnswers(question, sortOrder);
            return View(question);
        }

        public Question SortAnswers(Question question, string sortOrder)
        {
            switch (sortOrder)
            {
                case "time_asc":
                    question.Answers = question.Answers.OrderBy(a => a.TimeCreated).ToList();
                    break;
                case "time_desc":
                    question.Answers = question.Answers.OrderByDescending(a => a.TimeCreated).ToList();
                    break;
                case "likes_asc":
                    question.Answers = question.Answers.OrderBy(a => a.Ratings.Where(r => r.Likes.Equals(true)).Count()).ToList();
                    break;
                case "likes_desc":
                    question.Answers = question.Answers.OrderByDescending(a => a.Ratings.Where(r => r.Likes.Equals(true)).Count()).ToList();
                    break;
                case "dislikes_asc":
                    question.Answers = question.Answers.OrderBy(a => a.Ratings.Where(r => r.Likes.Equals(false)).Count()).ToList();
                    break;
                case "dislikes_desc":
                    question.Answers = question.Answers.OrderByDescending(a => a.Ratings.Where(r => r.Likes.Equals(false)).Count()).ToList();
                    break;
            }
            return question;
        }

        // GET: Questions/Create
        [Authorize(Roles = "user")]
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
        [Authorize(Roles = "user")]
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

        // GET: Questions/Delete/5
        [Authorize(Roles = "user, admin")]
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
        [Authorize(Roles = "user, admin")]
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

        [Authorize(Roles = "user")]
        public ActionResult Close(int id)
        {
            Question question = db.Questions.Find(id);
            question.Locked = true;
            question.TimeLastLocked = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Open(int id)
        {
            Question question = db.Questions.Find(id);
            question.Locked = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AnswerQuestion(int id)
        {
            return RedirectToAction("Create", "Answer", new { Id = id });
        }

        //public ActionResult FilterQuestions()
        //{
        //    var questions = db.Questions.Include(q => q.Channel1).Include(q => q.Category1);
        //    List<QuestionsIndexViewModel> questionList = new List<QuestionsIndexViewModel>();
        //    foreach (var question in questions)
        //    {
        //        var user = db.AspNetUsers.FirstOrDefault(usr => question.Author == usr.Id);
        //        QuestionsIndexViewModel model = new QuestionsIndexViewModel()
        //        {
        //            Question = question,
        //            AuthorName = user.FirstName + " " + user.LastName,
        //            AnswerCount = question.Answers.Count()
        //        };
        //        questionList.Add(model);
        //    }
        //    return View(questionList);
        //}
    }
}
