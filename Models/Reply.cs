using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int User_Id { get; set; }
        public int Comment_Id { get; set; }
        public DateTime Question_Date { get; set; }
        public int Evaluation { get; set; }
        public int Question_Id { get; set; }


        //public static bool AddReply(Reply reply)
        //{
        //    try
        //    {
        //        using (var ctx = new Enjaz_Context())
        //        {
        //            if (ctx.Comments.Where(s => s.User_Id == reply.User_Id && s.Id == reply.Question_Id).SingleOrDefault() != null || User.GetUserPoint(reply.User_Id) >= 15)
        //            {
        //                ctx.Replies.Add(reply);
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

        //public static bool VoteReply(int vote, Reply reply)
        //{
        //    try
        //    {
        //        using (var ctx = new Enjaz_Context())
        //        {
        //            var item = ctx.Comments.Where(s => s.User_Id == reply.User_Id && s.Id == reply.Question_Id).SingleOrDefault();
        //            if ( item != null || User.GetUserPoint(reply.User_Id) >= 20)
        //            {
        //                item.Evaluation = item.Evaluation + vote;
               
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

        //public static IEnumerable<Reply> GetReplies(int Comment_Id)
        //{
        //    Enjaz_Context _Context = new Enjaz_Context();
        //    return _Context.Replies/*.Where(r => r.Comment_Id == Comment_Id)*/.ToList();
                
        //        } 



    }
}
