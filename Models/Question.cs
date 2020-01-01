using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Enjaz_StackOverFlow.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int User_Id { get; set; }
        public DateTime Question_Date { get; set; }
        public string Tag_UserName { get; set; }
        public string Title { get; set; }
        public List<Question_History> question_Histories{ get; set; }


    }

    }
