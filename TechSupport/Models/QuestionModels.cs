using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechSupport.Models
{

    public class QuestionsIndexViewModel
    {
        public PagedList.IPagedList<QuestionsIndexViewModelItem> Questions {get;set;}
        public int Category { get; set; }
    }

    public class QuestionsSearchViewModel
    {
        public IEnumerable<QuestionsIndexViewModelItem> Questions { get; set; }
        public string SearchString { get; set; }
    }

    public class QuestionsIndexViewModelItem
    {
        public Question Question { get; set; }
        //public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AnswerCount { get; set; }
    }
}