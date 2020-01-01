using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Enjaz_StackOverFlow.Models;
using Enjaz_StackOverFlow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enjaz_StackOverFlow.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }




        [HttpPost("AddQuestion")]

        public async Task<ActionResult<Question>> AddUser(Question question)
        {
            question = await _questionService.AddQuestion(question);
            return Ok(question);

        }

       [Authorize(Roles ="MM")]
        [HttpPut("UpdateQuestion")]
        public async Task<ActionResult<Question>> UpdateQuestion(int Id, Question question)
        {
            var accessToken = Request.Headers["Authorization"];

            var userIdString = GetClaim("id");
            var userId =int.Parse(userIdString);
            question = await _questionService.UpdateQuestion(Id, question);
            return Ok(question);
        }
 

        [HttpGet("GetQuestion")]
        public async Task<ActionResult<Question>> GetQuestion()
        {
            return Ok(await _questionService.GetQuestions());
        }
        
        [HttpGet("GetQuestionById/{id}")]
        public async Task<ActionResult<Question>> GetQuestionById(int id)=>
         Ok(await _questionService.GetQuestionById(id));
       

        [HttpGet("SearchQuestion")]
        public async Task<ActionResult<Question>> SearchQuestion(string Search)
        {
            return Ok(await _questionService.SearchQuestion(Search));
        }





    }
}