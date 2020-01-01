using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Models
{
    public class Question_History
    {
        public int Id { get; set; }
        public int Qustion_Id { get; set; }
        [ForeignKey(nameof(Qustion_Id))]
        public Question Question { get; set; }
        public string Before_Edit { get; set; }
        public string After_Edit { get; set; }
        public DateTime Edit_DateTime { get; set; }



        //public static void AddHistoryQuestion(int Id_Question, Question question)
        //{

        ////    using (var ctx = new Enjaz_Context())
        ////    {
        ////        var item = ctx.Questions.Where(c => c.Id == Id_Question).SingleOrDefault();

        ////        if (item != null)
        ////        {

        ////            Question_History qh = new Question_History
        ////            {
        ////                Before_Edit = item.Description,
        ////                After_Edit = question.Description,
        ////                Edit_DateTime = DateTime.Now,
        ////                Qustion_Id = item.Id

        ////            };

        ////            ctx.Question_Histories.Add(qh);
        ////            ctx.SaveChanges();

        ////        }


        //    }




        //}
    }
}
