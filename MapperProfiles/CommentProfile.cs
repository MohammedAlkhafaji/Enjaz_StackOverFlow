using AutoMapper;
using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enjaz_StackOverFlow.MapperProfiles
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, Comment>();

//.ForAllMembers(opt => opt.Condition(
//(src, dest, srcMember) => srcMember != null)
//);


            CreateMap<CommentDto, Comment>();
        //.ForAllMembers(opt => opt.Condition(
        //  (src, dest, srcMember) => srcMember != null)
        //);
        }
    }
}
