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
    public class Question_HistoryController : BaseController
    {
        //Enjaz_Context _Context ;
        //public Question_HistoryController()
        //{
        //    _Context = new Enjaz_Context();
        //}

        //[HttpGet,ActionName("GetQuestionHistory")]
        //public IEnumerable<Question_History> question_Histories(int Question_Id)
        //{
        //    return _Context.Question_Histories.Where(q => q.Qustion_Id== Question_Id).ToList();
  
        //}

    }
}