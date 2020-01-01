using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Enjaz_StackOverFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace Enjaz_StackOverFlow.Services
{
    public class QuestionService : IQuestionService
    {

        private readonly Enjaz_Context ctx;
        private readonly IMapper _mapper;

        public QuestionService(Enjaz_Context context, IMapper mapper)
        {
            ctx = context;
            _mapper = mapper;
        }


        public async Task<Question> AddQuestion(Question question)
        {
            await ctx.Questions .AddAsync(question);
            await ctx.SaveChangesAsync();
            return question;
        }

        public async  Task<IEnumerable<Question>> GetQuestions()
        {
            return await ctx.Questions.Include(q=>q.question_Histories).ToListAsync();
        }

        public async  Task<Question> UpdateQuestion(int Id_Question, Question question)
        {
    
             var item = ctx.Questions.Where(c => c.Id == Id_Question).SingleOrDefault();
            Question_History qh = new Question_History
            {
                Before_Edit = item.Description,
                After_Edit = question.Description,
                Edit_DateTime = DateTime.Now
            };
            item.question_Histories.Add(qh);
            _mapper.Map(question , item);

            await ctx.SaveChangesAsync();
            return question ;
        }


        public async Task<IEnumerable<Question>> SearchQuestion(string Search)
        {
            return await ctx.Questions.Where(
                s => s.Title.Contains(Search)
                ||
                s.Description.Contains(Search)
                ).ToListAsync();
        }

        public async Task<Question> GetQuestionById(int id)=>
         await ctx.Questions.Include(q=>q.question_Histories).FirstOrDefaultAsync(q => q.Id == id);
        
    }
}
