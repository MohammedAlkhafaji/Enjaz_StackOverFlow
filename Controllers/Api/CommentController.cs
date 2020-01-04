using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using Enjaz_StackOverFlow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enjaz_StackOverFlow.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;
         public CommentController(ICommentService commentService)
        {
            _commentService  = commentService;
      
        }

 

        [HttpPost("AddComment")]
        public async Task<ActionResult<Comment>> AddComment(CommentDto comment)
        {
            var user_id = Convert.ToInt32(GetClaim("id"));
 
            comment  = await _commentService.AddComment(user_id , comment);
            return Ok(comment);
  

        }
     
        [HttpGet("GetComment")]
        public async Task<ActionResult<Comment>> GetComment(int Question_id)
        {
            return Ok( await  _commentService.GetComment(Question_id));
        }



        [HttpPost("AddReply")]
        public async  Task<ActionResult<Reply>> AddReply(ReplyDto reply)
        {
            var user_id = Convert.ToInt32(GetClaim("id"));

         return Ok(await _commentService.AddReply(user_id, reply));
        }

        [HttpPut("UpReply")]
        public async Task<ActionResult<Reply>> VoitUp(int comment_id)
        {
            var user_id = Convert.ToInt32(GetClaim("id"));

            return Ok(await _commentService.VoitUp(comment_id, user_id));
        }

        [HttpPut("DownReply")]
        public async Task<ActionResult<Reply>> VoitDown(int comment_id)
        {
            var user_id = Convert.ToInt32(GetClaim("id"));

            return Ok(await _commentService.VoitDown(comment_id, user_id));
        }



    }
}