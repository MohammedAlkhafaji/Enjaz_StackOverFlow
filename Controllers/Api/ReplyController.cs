using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enjaz_StackOverFlow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enjaz_StackOverFlow.Controllers.Api
{
    [Route("api/[controller]/[Action]/{id?}")]
    [ApiController]
    public class ReplyController : BaseController
    {


        //[HttpPost]
        //[ActionName("AddReply")]
        //public IActionResult AddReply(Reply reply)
        //{
        //    try
        //    {
        //        if (reply == null) return BadRequest("Null");

        //        var result = Reply.AddReply(reply);
        //        if (result == false) return BadRequest("false");
        //        return Ok("true");
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }


        //}

        //[HttpPut]
        //[ActionName("VoteReply")]
        //public IActionResult VoteReply(int Vote,Reply reply)
        //{
        //    try
        //    {
        //        if (reply == null) return BadRequest("Null");

        //        var result = Reply.VoteReply(Vote, reply);
        //        if (result == false) return BadRequest("false");
        //        return Ok("true");
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }


        //}

        //[HttpGet,ActionName("GetReply")]
        //public IEnumerable<Reply> GetReplies(int id_comment)
        //{
        //    return Reply.GetReplies(id_comment);
        //}

    }
}