using Enjaz_StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.Services
{
    public interface IQuestionService
    {

        Task<Question>AddQuestion(Question question);

        Task< IEnumerable<Question>> GetQuestions();
        
        Task<Question> UpdateQuestion(int Id_Question, Question question);

        Task<IEnumerable<Question>> SearchQuestion(string Search);
        Task<Question> GetQuestionById(int id);
    }
}
 
