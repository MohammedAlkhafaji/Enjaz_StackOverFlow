using AutoMapper;
using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.MapperProfiles
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, Question>()
 
        .ForAllMembers(opt => opt.Condition(
           (src, dest, srcMember) => srcMember != null)
        );


            CreateMap<QuestionForm, Question >()
        .ForAllMembers(opt => opt.Condition(
          (src, dest, srcMember) => srcMember != null)
        );


        }


    }
}
