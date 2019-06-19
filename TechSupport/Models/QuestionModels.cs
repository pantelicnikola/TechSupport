using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechSupport.Models
{
    public class QuestionsIndexViewModel
    {
        public Question Question { get; set; }
        //public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AnswerCount { get; set; }
    }
}