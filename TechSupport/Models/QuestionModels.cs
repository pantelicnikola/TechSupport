using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechSupport.Models
{

    public class QuestionsIndexViewModel
    {
        public IEnumerable<QuestionsIndexViewModelItem> questions {get;set;}
        public int Category { get; set; }
        //public Category Category { get; set; }

    }

    public class QuestionsIndexViewModelItem
    {
        public Question Question { get; set; }
        //public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AnswerCount { get; set; }
    }
}