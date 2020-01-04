using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Hubs;
using Enjaz_StackOverFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace Enjaz_StackOverFlow.Services
{
    public class CommentService : ICommentService
    {
        private readonly Enjaz_Context ctx;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ApiHub _apiHub;

        public CommentService(Enjaz_Context context, IMapper mapper, IUserService userService, ApiHub apiHub)
        {
            ctx = context;
            _mapper = mapper;
            _userService = userService;
            _apiHub = apiHub;
        }


        public async Task<CommentDto> AddComment(int user_id, CommentDto newcomment)
        {
            var item = ctx.Questions.Where(q => q.Id == newcomment.Question_Id && q.User_Id == user_id).FirstOrDefault();

            if (item != null || await _userService.GetUserPoint(user_id) >= 10)
            {
                var comment = new Comment();
                _mapper.Map(newcomment, comment);
                await ctx.Comments.AddAsync(comment);
                await ctx.SaveChangesAsync();
                await _apiHub.SendComment(item.Id, comment);
                return newcomment;
            }
            else
            {
                return null;
            }



        }


        public async Task<IEnumerable<Comment>> GetComment(int qustion_id)
        {
            return await ctx.Comments.Where(c => c.Question_Id == qustion_id).ToListAsync();
        }



        public async Task<ReplyDto> AddReply(int user_id, ReplyDto newreply)
        {

            if (await _userService.GetUserPoint(user_id) >= 20)
            {
                var reply = new Reply();
                _mapper.Map(newreply, reply);
                await ctx.Replies.AddAsync(reply);
                await ctx.SaveChangesAsync();
                return newreply;
            }
            else
            {
                return null;
            }
        }

        public async Task<Reply> VoitUp(int comment_id, int user_id)
        {
            int user_point = Convert.ToInt32(await _userService.GetUserPoint(user_id));
            var item = ctx.Replies.Where(s => s.Comment_Id == comment_id).SingleOrDefault();

            if (item != null && user_point >= 20)
            {
                item.Evaluation = item.Evaluation + 1;
            }

            return item;

        }

        public async Task<Reply> VoitDown(int comment_id, int user_id)
        {
            int user_point = Convert.ToInt32(await _userService.GetUserPoint(user_id));
            var item = ctx.Replies.Where(s => s.Comment_Id == comment_id).SingleOrDefault();

            if (item != null && user_point >= 20)
            {
                item.Evaluation = item.Evaluation - 1;
            }

            return item;

        }

        public async Task<IEnumerable<Reply>> GetReplies(int comment_id) =>
            await ctx.Replies.Where(r => r.Comment_Id == comment_id).ToListAsync();
    }
}
