using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Enjaz_StackOverFlow.Dtos;
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

        public async Task<ActionResult<Question>> AddQuestion(Question question)
        {
            var point_user = Int32.Parse(GetClaim("point"));
            question = await _questionService.AddQuestion(point_user, question);
            return Ok(question);

        } 

     //   [Authorize(Roles ="MM")]
        [HttpPut("UpdateQuestion")]
        public async Task<ActionResult<Question>> UpdateQuestion(int Id_Question, QuestionForm question)
        {
         //   var accessToken = Request.Headers["Authorization"];

            var UserId= Convert.ToInt32( GetClaim("id"));
         
            return Ok(await _questionService.UpdateQuestion(Id_Question, UserId, question));
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