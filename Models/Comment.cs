using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Models
{
    public class Comment
    {


        public int Id { get; set; }
        public string Description { get; set; }
        public int User_Id { get; set; }
        public int Question_Id { get; set; }
        public DateTime Comment_Date { get; set; }
        public int Evaluation { get; set; }


        //public static bool AddComment( Comment comment)
        //{
        //    try
        //    {
        //        using (var ctx = new Enjaz_Context())
        //        {
        //            if (ctx.Questions .Where(s => s.User_Id  == comment.User_Id && s .Id ==comment.Question_Id ).SingleOrDefault()!=null ||User.GetUserPoint(comment.User_Id )>=10 )
        //            {
        //                ctx.Comments.Add(comment);
        //                ctx.SaveChanges();
        //                return true;
        //            }
        //            else
        //            {
        //                return false;

        //            }

        //        }
        //    }

        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}


 


    }
}
