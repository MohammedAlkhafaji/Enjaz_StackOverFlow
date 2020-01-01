using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Dtos
{
    public class QuestionForm
    {


        public int Id { get; set; }
        public string Description { get; set; }
        public int User_Id { get; set; }
        public DateTime Question_Date { get; set; }
        public string Tag_UserName { get; set; }
        public string Title { get; set; }
    }
}
