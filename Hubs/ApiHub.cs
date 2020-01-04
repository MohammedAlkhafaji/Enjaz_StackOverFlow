using Enjaz_StackOverFlow.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Hubs
{
    public class ApiHub:Hub
    {


        public Task SendComment(int question_id, Comment comment  )
        {
            return Clients.All .SendAsync("question_" + question_id, Newtonsoft.Json.JsonConvert.SerializeObject(comment));
        }
    }
}
