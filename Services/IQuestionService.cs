using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Services
{
    public interface IQuestionService
    {

        Task<Question>AddQuestion(int user_point, Question question);

        Task< IEnumerable<Question>> GetQuestions();
        
        Task<QuestionForm> UpdateQuestion(int id_question,int id_user, QuestionForm question);

        Task<IEnumerable<Question>> SearchQuestion(string Search);

        Task<Question> GetQuestionById(int id);
    }
}
 
