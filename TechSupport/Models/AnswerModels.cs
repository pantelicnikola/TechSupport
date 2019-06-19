using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechSupport.Models
{
    public class AnswerQuestionViewModel
    {
        public int? IdQuestion { get; set; }
        public int IdAnswer { get; set; }
        public string QuestionTitle { get; set; }
        public string AnswerText { get; set; }
    }


}