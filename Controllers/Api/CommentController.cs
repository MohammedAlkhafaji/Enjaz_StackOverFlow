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
    public class CommentController : BaseController
    {
        //[HttpPost,ActionName("AddComment")]
        //public IActionResult AddComment(Comment comment)
        //{
        //    var result = Comment .AddComment (comment );
        //    if (result == false) return BadRequest("false");
        //    return Ok("true");
        //}




    }
}