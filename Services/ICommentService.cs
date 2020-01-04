using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Services
{
    public interface ICommentService
    {

        Task<CommentDto> AddComment(int user_id, CommentDto newcomment);

        Task<IEnumerable<Comment>> GetComment(int qustion_id);



        Task<IEnumerable<Reply>> GetReplies(int comment_id);
        Task<ReplyDto> AddReply(int user_id, ReplyDto reply);

        Task<Reply> VoitUp(int comment_id, int user_id);

        Task<Reply> VoitDown(int comment_id, int user_id);



    }
}
